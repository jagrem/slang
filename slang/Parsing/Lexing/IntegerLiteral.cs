using System;

namespace slang.Parsing.Lexing
{
    public class IntegerLiteral : Token
    {
        public IntegerLiteral (string value)
        {
            Value = value;
        }
    }
}

