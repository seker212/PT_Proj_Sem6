from src.poker.Player import Player

class Pot:
    def __init__(self):
        self.ammount: int = 0
        self.members: list[Player] = []