from typing import Iterator, Optional
from src.poker.Player import Player, Blind

class TablePlayers:
    def __init__(self, playerList: list[Player]) -> None:
        self.List: list[Player] = playerList
        self.saveIndex: Optional[int] = None

    def __iter__(self) -> Iterator[Player]:
        self.index: int = 0
        self.lastIndex: Optional[int] = None
        return self
    
    def __next__(self) -> Player:
        player = self.List[self.index]
        if self.lastIndex is not None and self.index == self.lastIndex:
            raise StopIteration
        if (self.index == len(self.List)-1):
            self.index = 0
        else:
            self.index += 1
        return player
    
    def __getitem__(self, key: int) -> Player:
        return self.List[key]

    def __len__(self) -> int:
        return len(self.List)

    def __str__(self) -> str:
        end = '[ '
        for p in self.List:
            end += p.user + ' '                 #FIXME: USER needs __str__()
        end += ']'
        return end
    
    def append(self, element: Player) -> None:
        return self.List.append(element)

    def setIterSB(self) -> None:
        """ Sets object iterator to player with small blind. """
        i = 0
        for p in self.List:
            if p.blind == Blind.small:
                break
            i += 1
        if i == len(self.List) and self.saveIndex is not None:
            self.index = self.saveIndex
        else:
            self.index = i
            self.saveIndex = i
        self.lastIndex = None

    def setLastPlayer(self) -> None:
        """Sets index of current player, to stop iteration """
        if self.index == 0:
            self.lastIndex = len(self.List)-1
        else:
            self.lastIndex = self.index - 1