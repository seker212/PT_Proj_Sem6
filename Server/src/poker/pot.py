from src.poker.Player import Player, Status

class Pot:
    def __init__(self):
        self.ammount: int = 0
        self.members: list[Player] = []
        self.required: int = 0
    
    def all_in_ammount(self) -> int: #FIXME: what if this is not the only pot?; <-- DO I EVEN USE THIS???
        for p in self.members:
            if p.status == Status.all_in:
                return p.table_money
        return -1

    def required_ammount(self) -> int:
        all_in_amm = self.all_in_ammount()
        if all_in_amm != -1:
            return all_in_amm
        else:
            return self.ammount/len(self.members)
        