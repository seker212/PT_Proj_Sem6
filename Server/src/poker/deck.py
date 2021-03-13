import enum
from random import shuffle

RANKS = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
SUITES = [Suit('diamonds', '♦️'), Suit('hearts', '♥️'), Suit('clubs', '♣️'), Suit('spades', '♠️')]

class Suit:
    def __init__(self, name, symbol):
        self.name = name
        self.symbol = symbol
    
    def __eq__(self, other):
        if other == None:
            return False
        if self.name == other.name and self.symbol == other.symbol:
            return True
        else:
            return False
    
    def __ne__(self, other):
        return (not self == other)

class Card:
    def __init__(self, suit, rank):
        self.suit = suit
        self.rank = rank
    
    def __str__(self):
        return self.rank+self.suit.symbol

    def __eq__(self, other):
        return self.rank == other.rank and self.suit == other.suit

def NewShuffledDeck():
    """Generates new full deck shuffled

    Returns:
        list: a list of Cards
    """
    global RANKS
    global Suit
    L = []
    for s in SUITES:
        for r in RANKS:
            L.append(Card(s,r))
    shuffle(L)
    return L