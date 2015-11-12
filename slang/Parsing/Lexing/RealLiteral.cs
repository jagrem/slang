using System;

namespace slang.Parsing.Lexing
{
    public class RealLiteral : Token
    {
        public RealLiteral (string value)
        {
            Value = value;
        }
    }
}

