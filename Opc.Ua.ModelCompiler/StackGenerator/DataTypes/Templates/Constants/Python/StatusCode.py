// ***START***
class StatusUtils:    
    @staticmethod
    def is_good(value) -> bool:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'code'):
                code = value.code
        return code is None or (code & 0xD0000000) == 0

    @staticmethod
    def is_uncertain(value) -> bool:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'code'):
                code = value.code
        return code is not None and (code & 0x40000000) != 0

    @staticmethod
    def is_bad(value) -> bool:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'code'):
                code = value.code
        return code is not None and (code & 0x80000000) != 0

    @staticmethod
    def code_bits(value) -> int:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'code'):
                code = value.code
        return (code & 0xFFFF0000) if code is not None else 0

    @staticmethod
    def info_bits(value) -> int:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'code'):
                code = value.code
        return (code & 0x0000FFFF) if code is not None else 0
            
    @staticmethod
    def to_text(value) -> str:
        code = value if isinstance(value, int) else None
        if (code is None):
            if hasattr(value, 'symbol') and value.symbol:
                return value.symbol
            if hasattr(value, 'code'):
                code = value.code
        return StatusCodes(code or 0).name
// ***END***