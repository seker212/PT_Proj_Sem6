from src.poker.player_actions import *
from src.poker.pot import Pot
from src.poker.table_players import TablePlayers
from src.poker.Player import Player

def test_call():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    p3.table_money = 150

    table = Table(TablePlayers([p1, p2, p3, p4]))

    pot1 = Pot()
    pot1.members = [p1, p2, p3, p4]
    pot1.ammount = 400
    pot1.required = 100

    pot2 = Pot()
    pot2.members = [p2, p4]
    pot2.ammount = 250
    pot2.required = 200

    pot3 = Pot()
    pot3.members = [p2]
    pot3.ammount = 50
    pot3.required = 250

    table.pots = [pot1, pot2, pot3]
    
    assert call(table, p3) == ActionEffect.OK

    assert len(table.pots) == 3

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p2, p4, p3]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 100
    assert table.pots[2].members == [p2, p3]
    assert table.pots[2].required == 250

    assert table.players[2].table_money == 250

def test_bet_raise():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    p1.status = Status.all_in
    p4.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 250
    p3.table_money = 150
    p4.table_money = 200

    table = Table(TablePlayers([p1, p2, p3, p4]))
    
    pot1 = Pot()
    pot1.members = [p1, p2, p3, p4]
    pot1.ammount = 400
    pot1.required = 100

    pot2 = Pot()
    pot2.members = [p2, p4]
    pot2.ammount = 250
    pot2.required = 200

    pot3 = Pot()
    pot3.members = [p2]
    pot3.ammount = 50
    pot3.required = 250

    table.pots = [pot1, pot2, pot3]
    assert bet_raise(table, p3, 100) == ActionEffect.OK

    assert len(table.pots) == 3

    assert p3.table_money == 250

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p2, p4, p3]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 200
    assert table.pots[2].members == [p3]
    assert table.pots[2].required == 350

def test_all_in():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    p1.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 100

    table = Table(TablePlayers([p1, p2, p3]))
    while (table.turnPlayer != p2):
        table.nextPlayer()

    pot1 = Pot()
    pot1.members = [p1, p2, p3, p4]
    pot1.ammount = 400
    pot1.required = 100

    pot2 = Pot()
    pot2.members = [p3, p4]
    pot2.ammount = 250
    pot2.required = 200

    pot3 = Pot()
    pot3.members = [p4]
    pot3.ammount = 100
    pot3.required = 300

    table.pots = [pot1, pot2, pot3]

    assert all_in(table, p2) == ActionEffect.OK

    assert len(table.pots) == 4
    assert p2.status == Status.all_in
    assert p2.table_money == 250

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p3, p4, p2]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 100
    assert table.pots[2].members == [p4, p2]
    assert table.pots[2].required == 250

    assert table.pots[3].ammount == 50
    assert table.pots[3].members == [p4]
    assert table.pots[3].required == 300