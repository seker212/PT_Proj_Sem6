from enum import Enum
from typing import Iterator
from src.poker.table_players import TablePlayers
from src.poker.Player import Player, Blind
from src.poker.pot import Pot
from src.poker.deck import Card, NewShuffledDeck

class GameStage(Enum):
    preFlop = 0
    Flop = 1
    Turn = 2
    River = 3
    Showdown = 4

class Table:
    def __init__(self, players: TablePlayers):
        self.stage: GameStage = GameStage.preFlop
        self.main_pot: Pot = Pot()
        self.site_pot: Pot = Pot()
        self.players: TablePlayers = players #TODO: Exception: Check if len(playerList) > 1
        self.number_of_deals: int = 0
        self.cards: list[Card] = NewShuffledDeck()[:2*len(self.players)+5]
        self.playerIt: Iterator[Player] = iter(self.players)

        next(self.playerIt).blind = Blind.small
        next(self.playerIt).blind = Blind.big
        self.turnPlayer: Player = next(self.playerIt)

        self.players.setLastPlayer()

    def giveHand(self) -> None:
        """ Removes cards form self.cards and add 2 to each player """
        for p in self.players.List:
            for x in range(2):
                p.hand.append(self.cards.pop())
    
    def nextStage(self) -> None:
        self.stage = GameStage(self.stage.value + 1)
        #TODO: czegos tu brakuje