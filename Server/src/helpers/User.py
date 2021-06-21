class User():
    def __init__(self, id: str, name: str):
        self.id: str = id
        self.name: str = name
    
    def __hash__(self):
        return hash(self.id)

    def __eq__(self, other):
        if not isinstance(other, User):
            return NotImplemented
        return self.id == other.id
    
    def __ne__(self, other):
        return not self.__eq__(other)

    def __str__(self):
        return f'<User id:{self.id}>'     