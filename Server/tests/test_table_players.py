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