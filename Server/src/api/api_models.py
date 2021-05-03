class CardModel():
    def __init__(self, suit: str, rank: str):
        self.suit = suit
        self.rank = rank 

class PotModel():
    def __init__(self, ammount: int, members: list):
        self.ammount = ammount
        self.members = members

class PlayerModel():
    def __init__(self, player_name: str, money: int):
        self.player_name = player_name
        #TODO: Add status/history
        self.money = money

class TableModel():
    def __init__(self, pots: list, players: list, player_turn:str , cards: list):
        self.pots = pots
        self.players = players 
        self.player_turn = player_turn
        self.cards = cards

class PlayerHandModel():
    def __init__(self, hand_type: str, hand: list):
        self.hand_type = hand_type
        self.hand = hand

class ShowdownModel():
    def __init__(self, players_hands: dict, winners: list, pot):
        self.pot = pot
        self.players_hands = players_hands
        self.winners = winners