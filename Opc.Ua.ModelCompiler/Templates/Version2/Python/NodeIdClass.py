// ***START***
class _NodeClass_Ids(Enum):
    // ListOfIdentifiers

def get__NodeClass_Ids_name(value: str) -> str:
    try:
        return _NodeClass_Ids(value).name
    except ValueError:
        return None

// ***END***
