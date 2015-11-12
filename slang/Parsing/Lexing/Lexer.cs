using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace slang.Parsing.Lexing
{
    public static class Lexer
    {
        public static IEnumerable<Token> Analyze(string input)
        {
            yield return new Start ();

            var booleanLiteralPattern = new Regex ("true|false", RegexOptions.IgnoreCase);

            if(booleanLiteralPattern.IsMatch (input)) {
                yield return new BooleanLiteral (input);
            }

            var integerLiteralPattern = new Regex (@"^(\d+|0[xX][0-9a-fA-F]+)(l|L|ul|Ul|UL|uL|lu|Lu|LU|uL)?$");

            if(integerLiteralPattern.IsMatch (input)) {
                yield return new IntegerLiteral (input);
            }

            var realLiteralPattern = new Regex (@"^(\d+[f|F|d|D|m|M]|\d+([eE][-+]?\d+)[f|F|d|D|m|M]?|\.\d+([eE][-+]?\d+)?[f|F|d|D|m|M]?|\d+\.\d+([eE][-+]?\d+)?[f|F|d|D|m|M]?)$");

            if(realLiteralPattern.IsMatch (input)) {
                yield return new RealLiteral (input);
            }

            yield return new End ();
        }
    }
}

