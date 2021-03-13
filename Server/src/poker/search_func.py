from poker.deck import *

def countCards(card, cardList):
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

def findCard(card, cardList):
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

def has_straight(cR):
    """Checks if player has a straight in hand

    Args:
        cR (list): list of ints - represents ammount of card of each rank in hand starting form Ace down to 2 

    Returns:
        int: index of the highest card in straight
        None: if can't form a straight
    """
    i = 0
    s = None
    t = False
    for x in cR:
        if x != 0:
            i += 1
        else:
            i = 0
        if i == 1:
            s = x
        if i == 0 and t == False:
            s = None
        if x == 5:
            t = True
            return s
    return None

def flush(suit, cR, handCards):
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
            c =findCard(Card(suit,Ranks[12-index]), handCards) 
            if c != None:
                hand.append(c)
                if len(hand) == 5:
                    return hand

def revRankIndex(rank):
    """Reverts card Rank index form ranks table with 2 having index 0
    to table with Ace having index 0

    Args:
        rank (string): number or big letter representing card's rank

    Returns:
        int: index representing rank where 0 means Ace and so on
    """
    for index in range(13):
        if Ranks[12-index] == rank:
            return index

def flushSuit(cS):
    """Checks suit of a flush

    Args:
        cS (list): list of ints - represents ammount of card of each suit in hand [♦️, ♥️, ♣️, ♠️]

    Returns:
        int: index of suit from cS
    """
    for x in range(4):
        if cS[x] >= 5:
            return x

def firstNo0(n, lista, avoid = None):
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

def sameSuitStr(start, suit, hand):
    """Checks if a straight is of a particular suit

    Args:
        start (int): index of highest Rank of straight where 0 is Ace and 12 is 2
        suit (Suit): suit to check
        hand (list): list of Cards representing player's hand

    Returns:
        bool: True if straight is of this suit, False otherwise 
    """
    start = 12 - start
    for rank in range(start, start-5, -1):
        for card in hand:
            if findCard(Card(suit, Ranks[rank]), hand) == None:
                return False
    return True