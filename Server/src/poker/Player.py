import enum
from typing import Any
from src.poker.variables import *
from src.poker.deck import Card

class Blind(enum.Enum):
    """Enum class"""
    none = 0
    small = 1
    big = 2

class Player:
    def __init__(self, player: Any):
        """Constructor

        Args:
            player : object to identify who represents player
        """
        self.user: Any = player
        self.hand: list[Card] = []
        self.money: int = STARTING_MONEY
        self.table_money: int = 0
        self.blind: Blind = Blind.none
        self.fold: bool = False
        self.all_in: bool = False
        self.check: bool = False
    
    def __str__(self) -> str:
        return self.user + ': ' + str(self.hand[0]) + ' ' + str(self.hand[1]) + ' ' + str(self.money) + ' ' + str(self.table_money) + ' ' + self.blind.name + ' ' + str(self.fold) + ' ' + str(self.all_in) + ' ' + str(self.check) #FIXME: USER needs __str__()

    def __eq__(self, other) -> bool:
        if not isinstance(other, Player):
            return NotImplemented

        return self.user == other.user #TODO: USER needs __eq__()