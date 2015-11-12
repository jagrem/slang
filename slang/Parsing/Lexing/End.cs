using System;

namespace slang.Parsing.Lexing
{
    public class End : Token
    {
        public End ()
        {
            Value = "EOF";
        }
    }
}

