from src.poker.Player import Player, Status

class Pot:
    def __init__(self):
        self.ammount: int = 0
        self.members: list[Player] = []
        self.required: int = 0