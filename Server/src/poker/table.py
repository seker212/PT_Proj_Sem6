from enum import Enum
from typing import Iterator, Optional
from src.poker.table_players import TablePlayers
from src.poker.Player import Player, Blind
from src.poker.pot import Pot
from src.poker.deck import Card, NewShuffledDeck
from src.poker.Hand import Hand, HandType
from src.helpers.pair import pair
from src.poker.variables import SMALL_BLIND

class GameStage(Enum):
    preFlop = 0
    Flop = 1
    Turn = 2
    River = 3
    Showdown = 4

class Table:
    def __init__(self, players: TablePlayers):
        self.stage: GameStage = GameStage.preFlop
        self.pots: list[Pot] = [Pot()]
        self.players: TablePlayers = players #TODO: Exception: Check if len(playerList) > 1
        self.number_of_deals: int = 0
        self.cards: list[Card] = NewShuffledDeck()[:2*len(self.players)+5]
        self.playerIt: Iterator[Player] = iter(self.players)

        next(self.playerIt).blind = Blind.small
        next(self.playerIt).blind = Blind.big
        self.turnPlayer: Player = next(self.playerIt)

        self.players.setLastPlayer()

    def nextPlayer(self) -> Player:
        self.turnPlayer = next(self.playerIt)
        return self.turnPlayer

    def giveHand(self) -> None:
        """ Removes cards form self.cards and add 2 to each player """
        for p in self.players.List:
            for x in range(2):
                p.hand.append(self.cards.pop())

    def nextStage(self) -> None:
        self.stage = GameStage(self.stage.value + 1)
        #TODO: czegos tu brakuje

    def getHands(self, pot: Pot) -> dict[Hand]:
        hand_dict = {}
        for x in pot.members:
            hand_dict[x] = Hand.evaluateHand(x.hand + table.cards)

    def getPlayerIndex(self, player: Player) -> Optional[int]:
        for i in range(len(self.players)):
            if self.players[i] == player:
                return i
        return None

    def getRequiredAmmount(self) -> int:
        return max(self.players.List, key= lambda p: p.table_money)

    def getWinners(self, hands: dict[Hand]) -> list[Player]:
        highest_handType = hands[min(hands, key=lambda x: hands[x].HandType.value)].HandType

        rm_tmp = []        
        for key in hands.keys():
            if hands[key].HandType != highest_handType:
                rm_tmp.append(key)
        for k in rm_tmp:
            hands.pop(k)
        del rm_tmp

        if len(hands) == 1:
            for key in hands.keys():
                return [key]
        elif len(hands) > 1:
            highest_handHight = hands[min(hands, key=lambda x: hands[x].hight)].hight
            rm_tmp = []
            for key in hands.keys():
                if hands[key].hight != highest_handHight:
                    rm_tmp.append(key)
            for k in rm_tmp:
                hands.pop(k)
            del rm_tmp
            if len(hands) == 1:
                for key in hands.keys():
                    return [key]
            elif len(hands) > 1:
                for i in range(len(next(iter(hands.values())).Kickers)):
                    tmp_list = []
                    rm_keys = []
                    for key in hands.keys():
                        if len(tmp_list) == 0 or hands[key].Kickers[i] < tmp_list[0].second:
                            tmp_list = [pair(key, hands[key].Kickers[i])]
                        elif hands[key].Kickers[i] == tmp_list[0].second:
                            tmp_list.append(pair(key, hands[key].Kickers[i]))
                        elif hands[key].Kickers[i] > tmp_list[0].second:
                            rm_keys.append(key)
                    if len(tmp_list) == 1:
                        return [tmp_list[0].first]
                    else:
                        for k in rm_keys:
                            hands.pop(k)
                return list(hands.keys())

    def getBlindsToPot(self) -> None:
        self.players.setIterSB()
        small_blind_player = self.nextPlayer()
        
        #FIXME: player might not have enough money
        
        self.pots[0].ammount += SMALL_BLIND
        p.money -= SMALL_BLIND
        p.table_money = SMALL_BLIND
        for p in self.players:
            if p.blind == Blind.small:
                self.pots[0].ammount += SMALL_BLIND
                p.money -= SMALL_BLIND
                p.table_money = SMALL_BLIND
            elif p.blind == Blind.big:
                self.pots[0].ammount += 2*SMALL_BLIND
                p.money -= 2*SMALL_BLIND
                self.pots[0].members += p
                p.table_money = 2*SMALL_BLIND

    def getCurrentCards(self):
        if self.stage == GameStage.preFlop:
            return []
        elif self.stage == GameStage.Flop:
            return self.cards[:3]
        elif self.stage == GameStage.Turn:
            return self.cards[:4]
        elif self.stage == GameStage.River or self.stage == GameStage.Showdown:
            return self.cards

            