using slang.Lexing.Tokens;
using System;

namespace slang.Lexing.Rules
{
    public abstract class Rule
    {
        public Func<string,Token> TokenCreator { get; set; }

        public static Rule operator | (Rule left, Rule right)
        {
            return new Or (left, right);
        }

        public static Rule operator + (Rule left, Rule right)
        {
            return new And (left, right);
        }

        public static implicit operator Rule (char value)
        {
            return new Constant (value);
        }

        public static implicit operator Rule (string value)
        {
            return new Constant (value);
        }

        public Rule Returns(Func<string,Token> tokenCreator = null)
        {
            TokenCreator = tokenCreator ?? new Func<string,Token>(context => Token.Empty);
            return this;
        }
    }
}
