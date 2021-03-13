import enum

class Hand:
    """ Final Hand Combinatin """
    def __init__(self, HandType, hight, Kickers):
        """Constructor

        Args:
            HandType (HandType): Enum representing type of final hand
            hight (int): index of card rank starting from Ace = 0
            Kickers (list): sorted list of indexes (int) representing cards that can be used as kickers; indexes starts with Ace = 0
        """
        self.HandType = HandType
        self.hight = hight #the lower the better [A, K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        self.Kickers = []
        self.Kickers += Kickers

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