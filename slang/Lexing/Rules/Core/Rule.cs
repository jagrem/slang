using slang.Lexing.Tokens;
using System;
namespace slang.Lexing.Rules.Core
{
    public abstract class Rule
    {
        public Func<Token> TokenCreator { get; set; }

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

        public Rule Returns(Func<Token> tokenCreator = null)
        {
            TokenCreator = tokenCreator ?? new Func<Token>(() => Token.Empty);
            return this;
        }
    }
}
