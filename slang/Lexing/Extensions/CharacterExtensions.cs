namespace slang.Lexing.Extensions
{
    static class CharacterExtensions
    {
        public static bool IsDigit(this char c)
        {
            switch(c) {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                return true;
            default:
                return false;
            }
        }

        public static bool IsHexadecimalDigit(this char c)
        {
            switch(c) {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
            case 'A':
            case 'B': 
            case 'C':
            case 'D':
            case 'E':
            case 'F':
                return true;
            default:
                return false;
            }
        }

        public static bool IsLongSpecifier(this char c) {
            return c == 'l' || c == 'L';
        }

        public static bool IsUnsignedSpecifier(this char c)
        {
            return c == 'u' || c == 'U';
        }

        public static bool IsDoubleSpecifier(this char c)
        {
            switch (c) {
            case 'd':
            case 'D':
                return true;
            default:
                return false;
            }
        }

        public static bool IsExponent(this char c)
        {
            switch(c)
            {
            case 'e':
            case 'E':
                return true;
            default:
                return false;
            }
        }

        public static bool IsFloatSpecifier(this char c)
        {
            switch(c)
            {
            case 'f':
            case 'F':
                return true;
            default:
                return false;
            }
        }

        public static bool IsDecimalSpecifier(this char c)
        {            switch(c)
            {
            case 'm':
            case 'M':
                return true;
            default:
                return false;
            }
        }

        public static bool IsDot(this char c)
        {
            return c == '.';
        }

        public static bool IsEnd(this char c)
        {
            return c == 0 || c == ' ';
        }

        public static bool IsSign(this char c)
        {
            return c == '+' || c == '-';
        }

    }
    
}
