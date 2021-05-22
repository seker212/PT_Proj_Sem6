from sys import path
if '' not in path:
    path.append('')

from flask import Flask
from flask_restful import Resource, Api
from apispec import APISpec
from apispec.ext.marshmallow import MarshmallowPlugin
from flask_apispec.extension import FlaskApiSpec
from flask_apispec.views import MethodResource
from flask_apispec import marshal_with, doc, use_kwargs

from src.helpers.KeyGenerator import generateStringKey
from src.helpers.User import User
from src.poker.table import Table, GameStage
from src.poker.table_players import TablePlayers
from src.poker.Player import Player
from src.poker.player_actions import bet_raise, all_in, call, check, fold, ActionEffect, AvailableActions
from src.api.api_schemas import *
from src.api.api_models import *

app = Flask(__name__)  # Flask app instance initiated
api = Api(app)  # Flask restful wraps Flask app around it.
app.config.update({
    'APISPEC_SPEC': APISpec(
        title='Poker Texas Hold\'em',
        version='dev',
        plugins=[MarshmallowPlugin()],
        openapi_version='2.0.0'
    ),
    'APISPEC_SWAGGER_URL': '/doc/swagger/',  # URI to access API Doc JSON
    'APISPEC_SWAGGER_UI_URL': '/doc/swagger/ui/',  # URI to access UI of API Doc
    'PREFERRED_URL_SCHEME': 'https',
    'SSL_DISABLE': 'False'
})
docs = FlaskApiSpec(app)

not_started_games = {}
started_games = {}
next_rounds_check = {}


class GetTableInfo(MethodResource, Resource):
    @doc(tags=['Get Info'])
    @marshal_with(TableSchema, code='200', description='Returns public table info')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID):
        if tableID not in started_games:
            return '', 404
        
        table = started_games[tableID]
        table_cards = [CardModel(card.suit.name, card.rank) for card in table.getCurrentCards()]
        table_pots = [PotModel(pot.ammount, [m.user.name for m in pot.members]) for pot in table.pots]
        table_players = [PlayerModel(p.user.name, p.money) for p in table.players.List]
        table_model = TableModel(table_pots, table_players, table.turnPlayer.user.name, table_cards)
        table_schema = TableSchema()
        return table_schema.dump(table_model), 200


api.add_resource(GetTableInfo, '/table/<tableID>')
docs.register(GetTableInfo)


class GetPlayerCards(MethodResource, Resource):
    @doc(tags=['Get Info'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(CardSchema(many=True), code='200', description='Returns array of 2 player cards')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        
        table = started_games[tableID]
        table_players = [p.user.id for p in table.players.List]
        if playerID not in table_players:
            return '', 403
        
        for p in table.players.List:
            if p.user.id == playerID:
                player_cards = [CardSchema().dump(CardModel(c.suit.name, c.rank)) for c in p.hand]
                return player_cards, 200

api.add_resource(GetPlayerCards, '/table/<tableID>/playercards')
docs.register(GetPlayerCards)


class AddTable(MethodResource, Resource):
    @doc(tags=['Manage'])
    @marshal_with(None, code='200', description='Returns new table\'s tableID as a string' )
    def post(self):
        key = generateStringKey()
        not_started_games[key] = []
        return key, 200

api.add_resource(AddTable, '/newtable')
docs.register(AddTable)


class AddPlayerToTable(MethodResource, Resource):
    @doc(tags=['Manage'])
    @use_kwargs({'playerName': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='Returns new player\'s playerID as a string' )
    @marshal_with(None, code='400', description='player name already taken')
    @marshal_with(None, code='404', description='tableID not found')
    def post(self, tableID, playerName):
        if tableID not in not_started_games:
            return '', 404
        
        table = not_started_games[tableID]

        if playerName in [user.name for user in table]:
            return 'Name already taken', 400

        key = generateStringKey()
        not_started_games[tableID].append(User(key, playerName))
        return key, 200

api.add_resource(AddPlayerToTable, '/newtable/join/<tableID>')
docs.register(AddPlayerToTable)


class NewTablePlayers(MethodResource, Resource):
    @doc(tags=['Manage'])
    @marshal_with(None, code='200', description='Returns new player\'s playerID as a string' )
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID):
        if tableID not in not_started_games:
            return '', 404
        
        table = not_started_games[tableID]
        return str([user.name for user in table]), 200

api.add_resource(NewTablePlayers, '/newtable/players/<tableID>')
docs.register(NewTablePlayers)


class StartTable(MethodResource, Resource):
    @doc(tags=['Manage'])
    @use_kwargs({'startingMoney': fields.Integer(), 'smallBlind': fields.Integer()}, location='querystring')
    @marshal_with(None, code='200', description='Success' )
    @marshal_with(None, code='400', description='Bad request')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, startingMoney, smallBlind):
        if tableID not in not_started_games:
            return '', 404
        
        table = not_started_games[tableID]
        if len(table) < 2:
            return 'Not enought players', 400
        if smallBlind <= 0:
            return 'Small blind amount has to be intiger greater than 0', 400
        if startingMoney <= 2*smallBlind:
            return 'Statring money ammount has to be greater than twice the small blind ammount', 400
        
        players = [Player(user, startingMoney) for user in table]
        started_games[tableID] = Table(TablePlayers(players), smallBlind)
        
        del not_started_games[tableID]
        return '', 200

api.add_resource(StartTable, '/newtable/start/<tableID>')
docs.register(StartTable)

class DisconnectPlayer(MethodResource, Resource):
    @doc(tags=['Manage'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='204', description='Disconnected' )
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def delete(self, tableID, playerID):
        table = None
        if tableID not in not_started_games:
            if tableID not in started_games:
                return '', 404
            else:
                table = started_games[tableID]
                if playerID not in [p.user.id for p in table.players.List]:
                    return '', 403
                else:
                    disconnect_player = None
                    for p in table.players.List:
                        if p.user.id == playerID:
                            disconnect_player = p
                            break
                    for pot in table.pots:
                        if disconnect_player in pot.members:
                            pot.members.remove(disconnect_player)
                    table.players.List.remove(disconnect_player)
                if tableID in next_rounds_check:
                    del next_rounds_check[tableID][playerID]
                    if all(next_rounds_check[tableID].values()):
                        table.initRound()
        else:
            table = not_started_games[tableID]
            if playerID not in [p.id for p in table]:
                return '', 403
            else:
                disconnect_player = None
                for p in table:
                    if p.id == playerID:
                        disconnect_player = p
                        break
                table.remove(disconnect_player)

api.add_resource(DisconnectPlayer, '/table/<tableID>/disconnect')
docs.register(DisconnectPlayer)


class NextRound(MethodResource, Resource):
    @doc(tags=['Manage'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='OK' )
    @marshal_with(None, code='400', description='')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def put(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if table.stage != GameStage.Showdown:
            return '', 400

        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        
        if tableID not in next_rounds_check:
            next_rounds_check[tableID] = {}
            for p in table.players.List:
                if playerID != p.user.id:
                    next_rounds_check[tableID][p.user.id] = False
                else:
                    next_rounds_check[tableID][p.user.id] = True
        else:
            next_rounds_check[tableID][playerID] = True
        
        if all(next_rounds_check[tableID].values()):
            table.dividePots()
            table.initRound()
        
api.add_resource(NextRound, '/table/<tableID>/nextround')
docs.register(NextRound)

class Showdown(MethodResource, Resource):
    @doc(tags=['Get Info'])
    @marshal_with(ShowdownSchema(many=True), code='200', description='OK' )
    @marshal_with(None, code='400', description='')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID):
        if tableID not in started_games:
            return '', 404

        table = started_games[tableID]
        if table.stage != GameStage.Showdown:
            return '', 400
        showdown_models = []
        pot_index = 0
        for pot in table.pots:
            players_hands_model_dict = {}
            players_hands = table.getHands(pot)
            for player in players_hands.keys():
                players_hands_model_dict[player.user.name] = PlayerHandModel(players_hands[player].HandType.name, [CardModel(c.suit.name, c.rank) for c in player.hand])
            winners = table.getWinners(players_hands)
            showdown_models.append(ShowdownModel(players_hands_model_dict.copy(), [w.user.name for w in winners], pot_index))
            pot_index += 1
        showdown_schemas = [ShowdownSchema().dump(model) for model in showdown_models]
        return showdown_schemas, 200

        
api.add_resource(Showdown, '/table/<tableID>/showdown')
docs.register(Showdown)


class Bet(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String(), 'ammount': fields.Integer()}, location='querystring')
    @marshal_with(None, code='200', description='Disconnected' )
    @marshal_with(None, code='400', description='Move not allowed')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID, ammount):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        player = None
        for p in table.players.List:
            if p.user.id == playerID:
                player = p
                break
        result = bet_raise(started_games[tableID], player, ammount)
        if result == ActionEffect.OK:
            started_games[tableID].nextTurnPlayer()
            return '', 200
        else:
            return result.name, 400
        
api.add_resource(Bet, '/table/<tableID>/actions/bet')
docs.register(Bet)


class Check(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='OK' )
    @marshal_with(None, code='400', description='Move not allowed')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        player = None
        for p in table.players.List:
            if p.user.id == playerID:
                player = p
                break
        result = check(started_games[tableID], player)

        if result == ActionEffect.OK:
            started_games[tableID].nextTurnPlayer()
            return '', 200
        else:
            return result.name, 400
        
api.add_resource(Check, '/table/<tableID>/actions/check')
docs.register(Check)


class Fold(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='OK' )
    @marshal_with(None, code='400', description='Move not allowed')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        player = None
        for p in table.players.List:
            if p.user.id == playerID:
                player = p
                break
        result = fold(started_games[tableID], player)

        if result == ActionEffect.OK:
            started_games[tableID].nextTurnPlayer()
            return '', 200
        else:
            return result.name, 400
        
api.add_resource(Fold, '/table/<tableID>/actions/fold')
docs.register(Fold)


class Call(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='OK' )
    @marshal_with(None, code='400', description='Move not allowed')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        player = None
        for p in table.players.List:
            if p.user.id == playerID:
                player = p
                break
        result = call(started_games[tableID], player)

        if result == ActionEffect.OK:
            started_games[tableID].nextTurnPlayer()
            return '', 200
        else:
            return result.name, 400
        
api.add_resource(Call, '/table/<tableID>/actions/call')
docs.register(Call)


class AllIn(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(None, code='200', description='OK' )
    @marshal_with(None, code='400', description='Move not allowed')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
        if tableID not in started_games:
            return '', 404
        table = started_games[tableID]
        if playerID not in [p.user.id for p in table.players.List]:
            return '', 403
        player = None
        for p in table.players.List:
            if p.user.id == playerID:
                player = p
                break
        result = all_in(started_games[tableID], player)

        if result == ActionEffect.OK:
            started_games[tableID].nextTurnPlayer()
            return '', 200
        else:
            return result.name, 400
        
api.add_resource(AllIn, '/table/<tableID>/actions/allin')
docs.register(AllIn)

class CheckMoves(MethodResource, Resource):
    @doc(tags=['Player Actions'])
    @use_kwargs({'playerID': fields.String()}, location='querystring')
    @marshal_with(AvailableActionsSchema, code='200', description='OK')
    @marshal_with(None, code='403', description='playerID not found')
    @marshal_with(None, code='404', description='tableID not found')
    def get(self, tableID, playerID):
            if tableID not in started_games:
                return '', 404
            table = started_games[tableID]
            if playerID not in [p.user.id for p in table.players.List]:
                return '', 403
            player = None
            for p in table.players.List:
                if p.user.id == playerID:
                    player = p
                    break
            
            result = AvailableActions(table, player)
            return result, 200

if __name__ == '__main__':
    # context = ('myCA.pem', 'myKey.key')
    # app.run(port=29345, ssl_context=context)
    app.run(port=29345)