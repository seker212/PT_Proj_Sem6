from typing import Optional
from src.poker.deck import *

def countCards(card : Card, cardList : list[Card]) -> int:
    """Counts the number cards with given Suit or Rank in a list

    Args:
        card (Card): Card object with either Suit or Rank being None 
        cardList (list): list of Cards

    Returns:
        int: number of cards
    """
    count = 0
    if card.suit != None:
        for c in cardList:
            if card.suit == c.suit:
                count += 1
    elif card.rank != None:
        for c in cardList:
            if card.rank == c.rank:
                count += 1
    return count

def findCard(card : Card, cardList : list[Card]) -> Optional[Card]:
    """ Finds first occurence of given card.
    If either Suit or Rank is None it finds card with parameter that wasn't None

    Args:
        card (Card): Card with search parameters
        cardList (list): list of Cards

    Returns:
        Card: First card found
        None: If card wasn't found
    """
    if card.suit != None and card.rank == None:
        for c in cardList:
            if card.suit == c.suit:
                return c
    elif card.rank != None and card.suit == None:
        for c in cardList:
            if card.rank == c.rank:
                return c
    elif card.suit != None and card.rank != None:
        for c in cardList:
            if card == c:
                return c
    return None

def has_straight(cR : list[int]) -> Optional[int]:
    """Checks if player has a straight in hand

    Args:
        cR (list): list of ints - represents ammount of card of each rank in hand starting form Ace down to 2 

    Returns:
        int: index of the highest card in straight
        None: if can't form a straight
    """
    index = 0
    count = 0
    s = None
    t = False
    for i in range(13):
        if cR[i] != 0:
            count += 1
        else:
            if count > 4:
                break
            else:
                count = 0
        if count == 1:
            index = i
    if count > 4:
        return index
    else:
        return None

def flush(suit : Suit, cR : list[int], handCards : list[Card]) -> list[Card]:
    """Gets cards that creates flush

    Args:
        suit (Suit): Suit of a flush
        cR (list): list of ints - represents ammount of card of each rank in hand starting form Ace down to 2 
        handCards (list): list of Cards representing player's hand

    Returns:
        list: list of 5 Cards creating flush 
    """
    hand = []
    for index in range(13):
        if cR[index] > 0:
            c =findCard(Card(suit,RANKS[index]), handCards) 
            if c is not None:
                hand.append(c)
                if len(hand) == 5:
                    return hand

def revRankIndex(rank : str) -> int:
    """Reverts card Rank index form ranks table with 2 having index 0
    to table with Ace having index 0

    Args:
        rank (string): number or big letter representing card's rank

    Returns:
        int: index representing rank where 0 means Ace and so on
    """
    for index in range(13):
        if RANKS[12-index] == rank:
            return index

def getRankIndex(rank: str) -> int:
    """Gets index from RANKS of given rank

    Args:
        rank (str): rank equal to one from RANKS

    Returns:
        int: index of element from RANKS
    """
    for index in range(13):
        if RANKS[index] == rank:
            return index

def flushSuit(cS : list[int]) -> int:
    """Checks suit of a flush

    Args:
        cS (list): list of ints - represents ammount of card of each suit in hand [♦️, ♥️, ♣️, ♠️]

    Returns:
        int: index of suit from cS
    """
    for x in range(4):
        if cS[x] >= 5:
            return x

def firstNo0(n : int, lista : list[int], avoid : Optional[int] = None) -> list[int]:
    """Gets a list of cards ranks form hand. Used to determin list of possible kickers

    Args:
        n (int): length of the list returned
        lista (list): list of ints - represents ammount of card of each rank in hand starting form Ace down to 2
        avoid (int, optional): index from lista that will be omitted. Defaults to None.

    Returns:
        list: sorted list of indexes (int) from lista representing cards ranks

    Example:
        firstNo0(4, [0, 1, 0, 2, 0, 2, 1, 0, 0, 0, 0, 1, 0], 3) -> [1, 6, 5, 5]
    """
    out = []
    i = 0
    for x in lista:
        if x != 0 and i != avoid:
            out += [i]*x
        i += 1
        if len(out) == n:
            return out
        elif len(out) > n:
            while len(out) > n:
                out.pop()
            return out

def sameSuitStr(start : int, suit : Suit, hand : list[Card]) -> Optional[int]:
    """Checks if a straight is of a particular suit

    Args:
        start (int): index of highest Rank of straight where 0 is Ace and 12 is 2
        suit (Suit): suit to check
        hand (list): list of Cards representing player's hand

    Returns:
        int: index of highest Rank of straight flush, None if no straight flush found 
    """
    found = False
    for i in range(start, start+3):
        for rank in range(i, i+5):
            if findCard(Card(suit, RANKS[rank]), hand) is None:
                break
            if rank == i+4:
                return i
    return None