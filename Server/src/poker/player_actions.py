import enum
from src.poker.table import Table
from src.poker.Player import Player, Status
from src.poker.pot import Pot

class ActionEffect(enum.Enum):
    OK = 0
    Not_enought_money = 1
    All_in_requred = 2
    Check_required = 3
    Arg_out_of_range = 4
    Too_little_ammount = 5
    Pot_is_close = 6
    Input_error = 7
    Wrong_player = 8
    Invalid_action = 9


def bet_raise(table: Table, player: Player, money: int) -> ActionEffect:
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player
    if money <= 0:
        return ActionEffect.Arg_out_of_range
    if table.turnPlayer.money < money + _to_call(table, player) - table.turnPlayer.table_money:
        return all_in(table, player)

    call(table, player)
    if any([p.status == Status.all_in for p in table.pots[len(table.pots)-1].members]):
        pot = Pot()
        pot.members = [player]
        pot.ammount = money
        pot.required = player.table_money + money
        player -= money
        table.pots.append(pot)
    else:
        table.pots[len(table.pots)-1].members = [player]
        table.pots[len(table.pots)-1].ammount += money
        table.pots[len(table.pots)-1].required = player.table_money + money
        player.money -= money

    table.players.setLastPlayer()

    return ActionEffect.OK

def fold(table: Table, player: Player) -> ActionEffect:
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player
    table.turnPlayer.status = Status.fold
    for pot in table.pots:
        if player in pot.members:
            pot.members.remove(player)
    return ActionEffect.OK

def check(table: Table, player: Player) -> ActionEffect:
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player
    if max(table.players.List, key= lambda p: p.table_money) != 0: #FIXME: Nope
        return ActionEffect.Invalid_action
    table.turnPlayer.status = Status.check
    return ActionEffect.OK

def all_in(table: Table, player: Player) -> ActionEffect: #FIXME: Add new pot if it doesn't need to split any existing
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player

    count_for_player = player.table_money
    prev_pot_req = 0
    i = 0
    for pot in table.pots:
        if pot.required > player.table_money + player.money:
            new_pot = Pot()
            new_pot.members = pot.members.copy()
            new_pot.members.append(player)
            new_pot.required = player.table_money + player.money
            if i != 0:
                new_pot.ammount = (new_pot.required-table.pots[i-1].required)*len(new_pot.members)
                pot.ammount -= (new_pot.required-table.pots[i-1].required)*(len(new_pot.members)-1)
            else:
                new_pot.ammount = (new_pot.required)*len(new_pot.members)
                pot.ammount -= (new_pot.required)*(len(new_pot.members)-1)
            player.table_money += player.money
            player.money = 0
            table.pots.insert(i, new_pot)
            break
        else:
            if player in pot.members:
                count_for_player -= pot.required - prev_pot_req
            else:
                pot.ammount += pot.required - prev_pot_req - count_for_player
                player.table_money += pot.required - prev_pot_req - count_for_player
                player.money -= pot.required - prev_pot_req - count_for_player
                pot.members.append(player)
                count_for_player = 0

            prev_pot_req = pot.required
            i += 1
    table.turnPlayer.status = Status.all_in
    return ActionEffect.OK

def call(table: Table, player: Player) -> ActionEffect: 
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player
    to_call = _to_call(table, player)
    if table.turnPlayer.money <= to_call - table.turnPlayer.table_money:
        return all_in(table, player)
    
    count_for_player = player.table_money
    prev_pot_req = 0
    for pot in table.pots:
        if player in pot.members:
            count_for_player -= pot.required - prev_pot_req
        else:
            pot.ammount += pot.required - prev_pot_req - count_for_player
            player.table_money += pot.required - prev_pot_req - count_for_player
            player.money -= pot.required - prev_pot_req - count_for_player
            pot.members.append(player)
            count_for_player = 0

        prev_pot_req = pot.required
    return ActionEffect.OK

def _to_call(table: Table, player: Player) -> int:
    if table.turnPlayer is None or table.turnPlayer != player:
        raise Exception
    return max(table.players.List, key= lambda p: p.table_money).table_money - table.turnPlayer.table_money