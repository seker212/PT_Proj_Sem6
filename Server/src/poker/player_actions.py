import enum
from typing import Dict
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

def AvailableActions(table: Table, player: Player) -> Dict:
    result = {}
    if player.status == Status.all_in or player.status == Status.fold:
        result['Can_move'] = False
        result['check'] = False
        result['call'] = False
        result['bet_raise'] = False
        return result
    else:
        result['Can_move'] = True
    to_call = _to_call(table, player)
    if player in table.pots[len(table.pots)-1].members and player.table_money == table.pots[len(table.pots)-1].required:
        result['check'] = True
    else:
        result['check'] = False

    if table.turnPlayer.money <= to_call - table.turnPlayer.table_money:
        result['call'] = False
        result['bet_raise'] = False
    else:
        result['call'] = True
        if table.turnPlayer.money-1 > to_call - table.turnPlayer.table_money:
            result['bet_raise'] = True
        else:
            result['bet_raise'] = False

    return result

def bet_raise(table: Table, player: Player, money: int) -> ActionEffect: #TODO: More tests
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

def check(table: Table, player: Player) -> ActionEffect: #TODO: Test this
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player
    if player in table.pots[len(table.pots)-1].members and player.table_money == table.pots[len(table.pots)-1].required:
        table.turnPlayer.status = Status.check
        return ActionEffect.OK
    else:
        return ActionEffect.Invalid_action

def all_in(table: Table, player: Player) -> ActionEffect:
    if table.turnPlayer is None or table.turnPlayer != player:
        return ActionEffect.Wrong_player

    count_for_player = player.table_money
    prev_pot_req = 0
    i = 0
    for pot in table.pots:
        if player not in pot.members:
            koszt = pot.required - prev_pot_req
            mozliwosc = player.table_money - prev_pot_req + player.money
            if koszt < mozliwosc:
                if any(player.status == Status.all_in for player in pot.members):
                    give = None
                    if player.table_money - prev_pot_req > 0:
                        give = koszt - (player.table_money - prev_pot_req)
                    else:
                        give = koszt    
                    pot.ammount += give
                    player.table_money += give
                    player.money -= give
                    pot.members.append(player)
                else:
                    pot.ammount += player.money
                    player.table_money += player.money
                    player.money = 0
                    pot.members = [player]
                    pot.required = player.table_money
                    table.players.setLastPlayer()
                    break

            elif koszt == mozliwosc:
                pot.ammount += player.money
                player.table_money += player.money
                player.money = 0
                pot.members.append(player)
                break
            else:
                new_pot = Pot()
                new_pot.members = pot.members.copy()
                new_pot.members.append(player)
                new_pot.required = player.table_money + player.money
                new_pot.ammount = (new_pot.required-prev_pot_req)*len(new_pot.members)
                if player.table_money - prev_pot_req > 0:
                    pot.ammount -= (new_pot.required-prev_pot_req)*(len(new_pot.members)-1)+(player.table_money - prev_pot_req)
                else:
                    pot.ammount -= (new_pot.required-prev_pot_req)*(len(new_pot.members)-1)
                player.table_money += player.money
                player.money = 0
                table.pots.insert(i, new_pot)
                break

        prev_pot_req = pot.required
        i += 1
    if player.money > 0:
        pot = Pot()
        pot.members = [player]
        pot.ammount = player.money
        player.table_money += player.money
        pot.required = player.table_money
        player.money = 0
        table.pots.append(pot)
        table.players.setLastPlayer()

    table.turnPlayer.status = Status.all_in
    return ActionEffect.OK

def call(table: Table, player: Player) -> ActionEffect: #TODO: More tests
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