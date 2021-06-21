import enum
from src.poker.search_func import *

class HandType(enum.Enum):
    royal_flash = 1
    straight_flash = 2
    four_of_a_kind = 3
    full_house = 4
    flush = 5
    straight = 6
    three_of_a_kind = 7
    two_pair = 8
    pair = 9
    high_hand = 10

class Hand:
    """ Final Hand Combinatin """
    def __init__(self, HandType : HandType, hight : int, Kickers : Optional[list[int]]):
        """Constructor

        Args:
            HandType (HandType): Enum representing type of final hand
            hight (int): index of card rank starting from Ace = 0
            Kickers (list): sorted list of indexes (int) representing cards that can be used as kickers; indexes starts with Ace = 0
        """
        self.HandType = HandType
        self.hight = hight #the lower the better [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        if Kickers is None:
            self.Kickers = []
        else:    
            self.Kickers = Kickers

    @classmethod
    def evaluateHand(cls, cards: list[Card]): #TODO: use cls param
        # Ranks [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        # cR [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        #     0  1  2  3  4   5  6  7  8  9 10 11 12
        # cS [♦️, ♥️, ♣️, ♠️]
        countRanks = []
        countSuits = []
        for x in RANKS:
            countRanks.append(countCards(Card(None, x), cards))
        maxRN = max(countRanks)

        if maxRN == 4:
            return Hand(HandType.four_of_a_kind, countRanks.index(4), firstNo0(1, countRanks, countRanks.index(4)))

        if maxRN == 3 and 2 in countRanks:
            return Hand(HandType.full_house, countRanks.index(3), [countRanks.index(2)]*2)

        straight = has_straight(countRanks)
        for x in SUITES:
            countSuits.append(countCards(Card(x, None),cards))
        maxSN = max(countSuits)

        if maxSN >= 5:
            fSN = flushSuit(countSuits)
            if straight != None:
                hight = sameSuitStr(straight, SUITES[fSN], cards)
                if hight is not None:
                    if straight == 0:
                        return Hand(HandType.royal_flash, hight, None)
                    else:
                        return Hand(HandType.straight_flash, hight, None)

            hand = flush(SUITES[fSN], countRanks, cards)
            kickers = []
            for x in range(1,5):
                kickers.append(getRankIndex(hand[x].rank))
            return Hand(HandType.flush, getRankIndex(hand[0].rank), kickers)

        if straight != None:
            return Hand(HandType.straight, straight, None)

        if maxRN == 3:
            return Hand(HandType.three_of_a_kind, countRanks.index(3), firstNo0(2, countRanks, countRanks.index(3)))
        if maxRN == 2:
            if countRanks.count(2) >= 2:
                kickers = []
                save = None
                for x in range(countRanks.index(2)+1, 13):
                    if countRanks[x] == 2:
                        kickers = [x]*2
                        save = x
                        break
                for x in range(13):
                    if x != countRanks.index(2) and x != save and countRanks[x] > 0:
                        kickers.append(x)
                        break
                return Hand(HandType.two_pair,countRanks.index(2),kickers)
            else:
                return Hand(HandType.pair, countRanks.index(2), firstNo0(3, countRanks, countRanks.index(2)))
        
        high = None
        for x in range(13):
            if countRanks[x] > 0:
                high = x
                break
        return Hand(HandType.high_hand, high, firstNo0(4, countRanks, high))
