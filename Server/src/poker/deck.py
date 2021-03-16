import enum
from random import shuffle
from typing import Optional

RANKS = ['A', 'K', 'Q', 'J', '10', '9', '8', '7', '6', '5', '4', '3', '2']

class Suit:
    def __init__(self, name : str, symbol : str):
        self.name = name
        self.symbol = symbol
    
    def __eq__(self, other) -> bool:
        if other is None:
            return False
        if self.name == other.name and self.symbol == other.symbol:
            return True
        else:
            return False
    
    def __ne__(self, other) -> bool:
        return (not self == other)

SUITES = [Suit('diamonds', '♦️'), Suit('hearts', '♥️'), Suit('clubs', '♣️'), Suit('spades', '♠️')]

class Card:
    def __init__(self, suit : Suit, rank : str):
        self.suit = suit
        self.rank = rank
    
    def __str__(self) -> str:
        return self.rank+self.suit.symbol

    def __eq__(self, other) -> bool:
        if other is None:
            return False
        else:
            return self.rank == other.rank and self.suit == other.suit

def NewShuffledDeck() -> list[Card]:
    """Generates new full deck shuffled

    Returns:
        list: a list of 52 Cards
    """
    global RANKS
    global Suit
    L = []
    for s in SUITES:
        for r in RANKS:
            L.append(Card(s,r))
    shuffle(L)
    return L