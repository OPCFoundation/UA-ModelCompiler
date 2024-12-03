// ***START***
from enum import Enum

class _ClassName_(Enum):
    // ListOfIdentifiers

def get__ClassName__name(value: int) -> str:
    try:
        return _ClassName_(value).name
    except ValueError:
        return None

// StatusCodeHelpers
// ***END***