using System;

namespace slang.Parsing.Lexing
{
    public class BooleanLiteral : Token
    {
        public BooleanLiteral (string value)
        {
            Value = value;
        }
    }
}

