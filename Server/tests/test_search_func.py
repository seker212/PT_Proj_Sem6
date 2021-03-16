from src.poker.search_func import *
from src.poker.deck import *

def test_straight():
    countRanks = [0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0]

    assert has_straight(countRanks) == 5