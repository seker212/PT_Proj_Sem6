from src.poker.table import *
from src.poker.table_players import TablePlayers
from src.poker.Player import Player

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