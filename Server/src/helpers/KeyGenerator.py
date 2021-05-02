from random import choices
from string import ascii_letters, digits

def generateStringKey() -> str:
    return ''.join(choices(ascii_letters+digits, k=16))