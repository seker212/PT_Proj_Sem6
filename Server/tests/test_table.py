from src.poker.table import *
from src.poker.table_players import TablePlayers
from src.poker.Player import Player
from src.poker.deck import *

def test_nextStage_stageInc():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    table = Table(TablePlayers([p1, p2, p3]))

    assert table.stage == GameStage.preFlop
    table.nextStage()
    assert table.stage == GameStage.Flop
    table.nextStage()
    assert table.stage == GameStage.Turn
    table.nextStage()
    assert table.stage == GameStage.River
    table.nextStage()
    assert table.stage == GameStage.Showdown

def test_giveHand_cardAmmount():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    table = Table(TablePlayers([p1, p2, p3]))

    assert len(table.cards) == 11
    table.giveHand()
    assert len(table.cards) == 5

    for p in table.players.List:
        assert len(p.hand) == 2

def test_getWinner_byKicker():
    p1 = Player("test1")
    p1_hand = [Card(SUITES[0], 'J'), Card(SUITES[2], '4')]
    p2 = Player("test2")
    p2_hand = [Card(SUITES[3], 'J'), Card(SUITES[3], '10')]
    p3 = Player("test3")
    p3_hand = [Card(SUITES[1], '10'), Card(SUITES[1], '7')]
    p_hands = [p1_hand, p2_hand, p3_hand]
    table = Table(TablePlayers([p1, p2, p3]))
    table_cards = [Card(SUITES[1], '2'), Card(SUITES[2], 'A'), Card(SUITES[3], '2'), Card(SUITES[1], '6'), Card(SUITES[2], '5')]

    for i in range(3):
        table.players.List[i].hand = p_hands[i]
    table.cards = table_cards

    hand_dict = {}
    for x in table.players.List:
        hand_dict[x] = Hand.evaluateHand(x.hand + table.cards)

    result = table.getWinners(hand_dict)
    assert len(result) == 1
    assert result[0].user == p2.user

def test_getWinner_byHandType():
    p1 = Player("test1")
    p1_hand = [Card(SUITES[1], '4'), Card(SUITES[3], '4')]
    p2 = Player("test2")
    p2_hand = [Card(SUITES[3], '8'), Card(SUITES[0], '10')]
    p3 = Player("test3")
    p3_hand = [Card(SUITES[0], 'Q'), Card(SUITES[0], 'A')]
    p_hands = [p1_hand, p2_hand, p3_hand]
    table = Table(TablePlayers([p1, p2, p3]))
    table_cards = [Card(SUITES[1], '3'), Card(SUITES[0], '3'), Card(SUITES[1], 'K'), Card(SUITES[0], '8'), Card(SUITES[0], '9')]

    for i in range(3):
        table.players.List[i].hand = p_hands[i]
    table.cards = table_cards

    hand_dict = {}
    for x in table.players.List:
        hand_dict[x] = Hand.evaluateHand(x.hand + table.cards)

    result = table.getWinners(hand_dict)
    assert len(result) == 1
    assert result[0].user == p3.user

def test_getWinner_byHeight():
    p1 = Player("test1")
    p1_hand = [Card(SUITES[1], '4'), Card(SUITES[3], '4')]
    p2 = Player("test2")
    p2_hand = [Card(SUITES[3], '8'), Card(SUITES[0], '10')]
    p3 = Player("test3")
    p3_hand = [Card(SUITES[2], '7'), Card(SUITES[0], 'A')]
    p_hands = [p1_hand, p2_hand, p3_hand]
    table = Table(TablePlayers([p1, p2, p3]))
    table_cards = [Card(SUITES[1], '3'), Card(SUITES[0], '3'), Card(SUITES[1], 'K'), Card(SUITES[0], '8'), Card(SUITES[0], '9')]

    for i in range(3):
        table.players.List[i].hand = p_hands[i]
    table.cards = table_cards

    hand_dict = {}
    for x in table.players.List:
        hand_dict[x] = Hand.evaluateHand(x.hand + table.cards)

    result = table.getWinners(hand_dict)
    assert len(result) == 1
    assert result[0].user == p2.user

def test_getWinner_2Players():
    p1 = Player("test1")
    p1_hand = [Card(SUITES[0], 'J'), Card(SUITES[3], '2')]
    p2 = Player("test2")
    p2_hand = [Card(SUITES[3], 'J'), Card(SUITES[0], '2')]
    p3 = Player("test3")
    p3_hand = [Card(SUITES[0], '6'), Card(SUITES[0], 'A')]
    p_hands = [p1_hand, p2_hand, p3_hand]
    table = Table(TablePlayers([p1, p2, p3]))
    table_cards = [Card(SUITES[2], 'Q'), Card(SUITES[2], 'J'), Card(SUITES[2], '9'), Card(SUITES[2], '7'), Card(SUITES[3], '3')]

    for i in range(3):
        table.players.List[i].hand = p_hands[i]
    table.cards = table_cards

    hand_dict = {}
    for x in table.players.List:
        hand_dict[x] = Hand.evaluateHand(x.hand + table.cards)

    result = table.getWinners(hand_dict)
    assert len(result) == 2
    assert result[0].user == p1.user
    assert result[1].user == p2.user