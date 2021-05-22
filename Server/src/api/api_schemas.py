from marshmallow import Schema, fields

class CardSchema(Schema):
    suit = fields.String(dump_only=True)
    rank = fields.String(dump_only=True)

class PotSchema(Schema):
    ammount = fields.Integer(dump_only=True)
    members = fields.List(fields.String(dump_only=True))

class PlayerSchema(Schema):
    player_name = fields.String(dump_only=True)
    #TODO: Add status/history
    money = fields.Integer(dump_only=True)

class TableSchema(Schema):
    pots = fields.List(fields.Nested(PotSchema), dump_only=True)
    players = fields.List(fields.Nested(PlayerSchema), dump_only=True)
    player_turn = fields.String(dump_only=True)
    cards = fields.List(fields.Nested(CardSchema), dump_only=True)

class PlayerHandSchema(Schema):
    hand_type = fields.String(dump_only=True)
    hand = fields.List(fields.Nested(CardSchema()), dump_only=True)

class ShowdownSchema(Schema):
    pot = fields.Integer(dump_only=True)
    players_hands = fields.Dict(fields.String(), fields.Nested(PlayerHandSchema), dump_only=True)
    winners = fields.List(fields.String(), dump_only=True)

class AvailableActionsSchema(Schema):
    Can_move = fields.Boolean()
    check = fields.Boolean()
    call = fields.Boolean()
    bet_raise = fields.Boolean()