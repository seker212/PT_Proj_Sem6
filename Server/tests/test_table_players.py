from src.poker.table_players import *
from src.poker.Player import *

def test_setLastPlayer():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")

    players = TablePlayers([p1, p2, p3])
    it = iter(players)
    assert next(it) == p1 
    assert next(it) == p2 
    players.setLastPlayer()
    i = 0
    while (x := next(it)) and x is not None:
        print(x.user)
        i += 1
        if i > 10:
            break
    assert i == 2
    assert next(it) == None

def test_setLastPlayer():
    p1 = Player("test1")
    p2 = Player("test2")
    p3 = Player("test3")

    players = TablePlayers([p1, p2, p3])
    it = iter(players)
    assert next(it) == p1 
    assert next(it) == p2 
    players.setLastPlayer()
    assert next(it) == p3
    assert next(it) == p1
    assert next(it) == None

def test_setSmallBlind():
    p1 = Player("test1")
    p2 = Player("test2")
    p2.blind = Blind.small
    p3 = Player("test3")

    players = TablePlayers([p1, p2, p3])
    it = iter(players)
    next(it)
    next(it)
    players.setIterSB()
    assert next(it) == p2
    assert next(it) != p2
    players.setIterSB()
    assert next(it) == p2
    players.setIterSB()
    assert next(it) == p2

def test_setLastPlayer_and_setSmallBlind():
    p1 = Player("test1")
    p2 = Player("test2")
    p2.blind = Blind.small
    p3 = Player("test3")

    players = TablePlayers([p1, p2, p3])
    it = iter(players)
    assert next(it) == p1 
    assert next(it) == p2 
    players.setLastPlayer()
    i = 0
    while (x := next(it)) and x is not None:
        i += 1
        if i > 10:
            break
    assert i == 2
    assert next(it) == None
    assert next(it) == None
    players.setIterSB()
    assert players.index == 1
    assert players.lastIndex == None
    assert next(it) == p2 
    players.setLastPlayer()
    assert next(it) == p3 
    assert next(it) == p1  
    assert next(it) == None