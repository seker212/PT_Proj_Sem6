from src.poker.player_actions import *
from src.poker.pot import Pot
from src.poker.table_players import TablePlayers
from src.poker.Player import Player
from src.poker.variables import *
from src.poker.table import *

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

def test_all_in_call_and_raise():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    table = Table(TablePlayers([p1, p2, p3, p4]))
    p1.status = Status.all_in
    p3.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 250

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

    assert len(table.pots) == 3
    assert p2.status == Status.all_in
    assert p2.table_money == 400
    assert p2.money == 0

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p3, p4, p2]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 300
    assert table.pots[2].members == [p2]
    assert table.pots[2].required == 400

    assert table.players.lastIndex == 1

def test_all_in_split_pot_with_part_in():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    table = Table(TablePlayers([p1, p2, p3, p4]))
    p1.status = Status.all_in
    p3.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 30

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
    assert p2.table_money == 180
    assert p2.money == 0

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 240
    assert table.pots[1].members == [p3, p4, p2]
    assert table.pots[1].required == 180

    assert table.pots[2].ammount == 40
    assert table.pots[2].members == [p3, p4]
    assert table.pots[2].required == 200

    assert table.pots[3].ammount == 100
    assert table.pots[3].members == [p4]
    assert table.pots[3].required == 300

def test_all_in_call_and_split_pot():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    table = Table(TablePlayers([p1, p2, p3, p4]))
    p1.status = Status.all_in
    p3.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 100

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
    assert p2.money == 0

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

def test_all_in_call_to_existing_pot():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    table = Table(TablePlayers([p1, p2, p3, p4]))
    p1.status = Status.all_in
    p3.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 50

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

    assert len(table.pots) == 3
    assert p2.status == Status.all_in
    assert p2.table_money == 200
    assert p2.money == 0

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p3, p4, p2]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 100
    assert table.pots[2].members == [p4]
    assert table.pots[2].required == 300

def test_all_in_create_new_pot_at_end():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")
    p4 = Player("test4")

    table = Table(TablePlayers([p1, p2, p3, p4]))
    p1.status = Status.all_in
    p3.status = Status.all_in
    p4.status = Status.all_in

    p1.table_money = 100
    p2.table_money = 150
    p3.table_money = 200
    p4.table_money = 300

    p2.money = 250

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
    assert p2.table_money == 400
    assert p2.money == 0

    assert table.pots[0].ammount == 400
    assert table.pots[0].members == [p1, p2, p3, p4]
    assert table.pots[0].required == 100

    assert table.pots[1].ammount == 300
    assert table.pots[1].members == [p3, p4, p2]
    assert table.pots[1].required == 200

    assert table.pots[2].ammount == 200
    assert table.pots[2].members == [p4, p2]
    assert table.pots[2].required == 300

    assert table.pots[3].ammount == 100
    assert table.pots[3].members == [p2]
    assert table.pots[3].required == 400

    assert table.players.lastIndex == 1

def test_combined_1():
    p1 = Player("test1", STARTING_MONEY)
    p2 = Player("test2", STARTING_MONEY)
    p3 = Player("test3", STARTING_MONEY)
    p4 = Player("test4", STARTING_MONEY)

    table = Table(TablePlayers([p1, p2, p3, p4]), SMALL_BLIND)

    assert table.stage == GameStage.preFlop

    assert table.pots[0].ammount == 3*SMALL_BLIND
    assert table.pots[0].members == [p2]
    assert table.pots[0].required == 2*SMALL_BLIND

    assert all_in(table, p3) == ActionEffect.OK
    table.nextTurnPlayer()
    assert p3.status == Status.all_in
    assert table.turnPlayer == p4
    assert len(table.pots) == 1
    assert table.pots[0].required == STARTING_MONEY
    assert table.pots[0].ammount == STARTING_MONEY + 3*SMALL_BLIND

    assert fold(table, p4) == ActionEffect.OK
    table.nextTurnPlayer()
    assert p4.status == Status.fold
    assert p4.table_money == 0
    assert p4.money == STARTING_MONEY
    assert table.turnPlayer == p1
    assert len(table.pots) == 1
    assert table.pots[0].required == STARTING_MONEY
    assert table.pots[0].ammount == STARTING_MONEY + 3*SMALL_BLIND

    assert all_in(table, p1) == ActionEffect.OK
    table.nextTurnPlayer()
    assert p1.status == Status.all_in
    assert table.turnPlayer == p2
    assert len(table.pots) == 1
    assert table.pots[0].required == STARTING_MONEY
    assert table.pots[0].ammount == 2*STARTING_MONEY + 2*SMALL_BLIND

    assert fold(table, p2) == ActionEffect.OK
    table.nextTurnPlayer()
    assert p2.status == Status.fold
    assert len(table.pots) == 1
    assert table.pots[0].required == STARTING_MONEY
    assert table.pots[0].ammount == 2*STARTING_MONEY + 2*SMALL_BLIND
    
    assert table.stage == GameStage.Showdown