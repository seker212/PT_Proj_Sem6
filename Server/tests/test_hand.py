from src.poker.Hand import *
from src.poker.deck import *

# Ranks [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
# cR [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
#     0  1  2  3  4   5  6  7  8  9 10 11 12
# cS [♦️, ♥️, ♣️, ♠️]

def test_two_pairs():
    card0 = Card(SUITES[1], 'K')
    card1 = Card(SUITES[2], 'Q')
    card2 = Card(SUITES[0], 'Q')
    card3 = Card(SUITES[2], 'A')
    card4 = Card(SUITES[2], 'K')
    card5 = Card(SUITES[0], '5')
    card6 = Card(SUITES[0], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.two_pair
    assert hand.hight == 0
    assert hand.Kickers == [1,1,2]

def test_straight_flash():
    card0 = Card(SUITES[0], 'A')
    card1 = Card(SUITES[1], '7')
    card2 = Card(SUITES[2], '6')
    card3 = Card(SUITES[2], '5')
    card4 = Card(SUITES[2], '4')
    card5 = Card(SUITES[2], '3')
    card6 = Card(SUITES[2], '2')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.straight_flash
    assert hand.hight == 8
    assert hand.Kickers == []

def test_royal():
    card0 = Card(SUITES[1], 'K')
    card1 = Card(SUITES[1], 'Q')
    card2 = Card(SUITES[1], '10')
    card3 = Card(SUITES[1], 'A')
    card4 = Card(SUITES[1], 'J')
    card5 = Card(SUITES[0], '5')
    card6 = Card(SUITES[0], '2')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.royal_flash
    assert hand.hight == 0
    assert hand.Kickers == []

def test_straight():
    card0 = Card(SUITES[0], 'J')
    card1 = Card(SUITES[1], 'Q')
    card2 = Card(SUITES[2], '7')
    card3 = Card(SUITES[3], '6')
    card4 = Card(SUITES[0], '5')
    card5 = Card(SUITES[0], '4')
    card6 = Card(SUITES[2], '3')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.straight
    assert hand.hight == 7
    assert hand.Kickers == []

def test_straight_not_royal():
    card0 = Card(SUITES[0], 'J')
    card1 = Card(SUITES[1], 'A')
    card2 = Card(SUITES[2], '7')
    card3 = Card(SUITES[3], 'Q')
    card4 = Card(SUITES[0], 'K')
    card5 = Card(SUITES[0], '10')
    card6 = Card(SUITES[2], '3')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.straight
    assert hand.hight == 0
    assert hand.Kickers == []

def test_four_of_a_kind():
    card0 = Card(SUITES[1], '8')
    card1 = Card(SUITES[2], '8')
    card2 = Card(SUITES[0], '8')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[2], 'K')
    card5 = Card(SUITES[0], '5')
    card6 = Card(SUITES[0], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.four_of_a_kind
    assert hand.hight == 6
    assert hand.Kickers == [0]

def test_full_house():
    card0 = Card(SUITES[1], 'K')
    card1 = Card(SUITES[2], 'K')
    card2 = Card(SUITES[0], '5')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[3], 'K')
    card5 = Card(SUITES[1], '5')
    card6 = Card(SUITES[0], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.full_house
    assert hand.hight == 1
    assert hand.Kickers == [9,9]

def test_three_of_a_kind():
    card0 = Card(SUITES[1], 'K')
    card1 = Card(SUITES[2], 'K')
    card2 = Card(SUITES[0], '5')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[3], 'K')
    card5 = Card(SUITES[1], '3')
    card6 = Card(SUITES[0], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.three_of_a_kind
    assert hand.hight == 1
    assert hand.Kickers == [0,6]

def test_pair():
    card0 = Card(SUITES[1], '10')
    card1 = Card(SUITES[2], '5')
    card2 = Card(SUITES[0], '5')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[3], 'K')
    card5 = Card(SUITES[1], '3')
    card6 = Card(SUITES[0], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.pair
    assert hand.hight == 9
    assert hand.Kickers == [0,1,4]

def test_flush():
    card0 = Card(SUITES[1], '10')
    card1 = Card(SUITES[2], '5')
    card2 = Card(SUITES[1], '5')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[1], 'K')
    card5 = Card(SUITES[1], '3')
    card6 = Card(SUITES[1], 'A')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.flush
    assert hand.hight == 0
    assert hand.Kickers == [1,4,9,11]

def test_high_hand():
    card0 = Card(SUITES[1], '10')
    card1 = Card(SUITES[2], '6')
    card2 = Card(SUITES[3], '5')
    card3 = Card(SUITES[3], '8')
    card4 = Card(SUITES[1], 'K')
    card5 = Card(SUITES[3], '3')
    card6 = Card(SUITES[2], 'J')

    hand = Hand.evaluateHand([card0, card1, card2, card3, card4, card5, card6])
    assert hand.HandType == HandType.high_hand
    assert hand.hight == 1
    assert hand.Kickers == [3,4,6,8]