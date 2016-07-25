using slang.Lexing.Rules;
using slang.Lexing.Tokens;

namespace slang.Lexing
{
    public static class SlangGrammar
    {
        public static Rule ToRule ()
        {
            var booleanLiteral = ((Rule)"true" | "false").Returns (context => new BooleanLiteral (context));

            var singleCharacter = new Range ('!', '&') | new Range('(', '[') | new Range (']', '~');
            var simpleEscapeSequence = '\\';
            var character = singleCharacter | simpleEscapeSequence;
            var characterLiteral = ('\'' + character + '\'').Returns (context => new CharacterLiteral(context));

            var decimalDigits = new Range ('0', '9');
            var decimalIntegerLiteral = new Repeat (decimalDigits);
            var integerLiteral = decimalIntegerLiteral.Returns (context => new IntegerLiteral (context));

            return booleanLiteral | characterLiteral | integerLiteral;
        }
    }
}

