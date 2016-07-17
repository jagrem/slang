using NUnit.Framework;
using slang.Lexing;
using slang.Lexing.Rules.Core;
using FluentAssertions;
using slang.Lexing.Tokens;
using System.Collections.Generic;
using System;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    public class LexingTests
    {
        class Literal : Token { public Literal (string value) : base (value) { } }
        class FunctionName : Token { public FunctionName (string value) : base (value) { } }
        class Identifier : Token { public Identifier (string value) : base(value) {} }
        class IntegerLiteral : Token { public  IntegerLiteral(string value) : base (value) { } }
        class Symbol : Token { public Symbol (string value) : base (value) { } }
        class Whitespace : Token { public Whitespace () : base (" ") { } }

        [TestCaseSource("GetTestCases")]
        public void Given_valid_input_and_a_constant_rule_When_lexed_Then_the_correct_tokens_are_returned(Rule rule, string input, IEnumerable<Token> expectedTokens)
        {
            var lexer = new Lexer2 (rule);
            var result = lexer.Scan (input);
            result.ShouldBeEquivalentTo (expectedTokens);
        }

        string GetTestCaseName(string rule, string input)
        {
            return string.Format ("Given a rule ({0}) and input '{1}' when lexed then the correct tokens are returned", rule, input);
        }


        IEnumerable<TestCaseData> GetTestCases ()
        {
            Func<string, Token> literal = context => new Literal (context);

            yield return
                new TestCaseData (
                ((Rule)'a').Returns (literal),
                "a",
                new [] { new Literal ("a") })
                    .SetName (GetTestCaseName ("Literal := 'a'", "a"));

            yield return new TestCaseData (
                ((Rule)'a' + 'b').Returns (literal),
                "ab",
                new [] { new Literal ("ab") })
                    .SetName (GetTestCaseName ("Literal := 'a' 'b'", "ab"));

            yield return new TestCaseData (
                ((Rule)'a' | 'b').Returns (literal),
                "a",
                new [] { new Literal ("a") })
                    .SetName ("Literal := 'a' | 'b'");

            yield return new TestCaseData (
                ('a' + ((Rule)'b' | 'c') + 'd').Returns (literal),
                "acd",
                new [] { new Literal ("acd") })
                    .SetName ("Literal := 'a' ('b' | 'c') 'd'");

            yield return new TestCaseData (
                new Repeat ('a').Returns (literal),
                "aaaa",
                new [] { new Literal ("aaaa") })
                    .SetName ("Literal := { 'a' }");

            yield return new TestCaseData (
                new Repeat ((Rule)'a' | 'b').Returns (literal),
                "abab",
                new [] { new Literal ("abab") })
                    .SetName ("Literal := { 'a' | 'b' }");

            var digits = (Rule)'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';
            var upperCaseHexadecimal = (Rule)'A' | 'B' | 'C' | 'D' | 'E' | 'F';
            var lowerCaseHexadecimal = (Rule)'a' | 'b' | 'c' | 'd' | 'e' | 'f';
            var initialCharacter = upperCaseHexadecimal;
            var medialCharacter = lowerCaseHexadecimal | digits;
            var finalCharacter = upperCaseHexadecimal;

            yield return
                new TestCaseData (
                    (initialCharacter + new Repeat (medialCharacter) + finalCharacter).Returns (literal),
                    "Ac02feD",
                    new [] { new Literal ("Ac02feD") }
                )
                .SetName ("Literal := hex");

            var uppercase = (Rule) 'A' | 'B' | 'C' | 'D' | 'E' | 'F' | 'G' | 'H' | 'I' | 'J' | 'K' | 'L' | 'M' | 'N' | 'O' | 'P' | 'Q' | 'R' | 'S' | 'T' | 'U' | 'V' | 'W' | 'X' | 'Y' | 'Z';
            var lowercase = (Rule)'a' | 'b' | 'c' | 'd' | 'e' | 'f'| 'g' | 'h' | 'i' | 'j' | 'k' | 'l' | 'm' | 'n' | 'o' | 'p' | 'q' | 'r' | 's' | 't' | 'u' | 'v' | 'w' | 'x' | 'y' | 'z';
            var alpha = uppercase | lowercase;
            var numeric = (Rule)'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';
            var alphanumeric = alpha | numeric;
            var symbols = (Rule)'-' | '_' | '+';
            var initial = alpha;
            var medial = alphanumeric | symbols;
            var functionName = (initial + new Repeat (medial)).Returns (context => new FunctionName (context));

            yield return
                new TestCaseData (
                    functionName,
                    "A-Function-Name-01 Function_Number_2 function+03",
                    new [] { new FunctionName ("A-Function-Name-01"), new FunctionName ("Function_Number_2"), new FunctionName("function+03") }
                )
                    .SetName ("Literal := initial { medial }");
            
            var whitespace = new Repeat(((Rule)' ' | '\t')).Returns (context => new Whitespace());
            var identifier = (initial + new Repeat (medial)).Returns (context => new Identifier (context));
            var integerLiteral = new Repeat (numeric).Returns (context => new IntegerLiteral(context));
            var symbol = ((Rule)'!' | '@' | '#' | '$' | '%' | '^' | '&' | '*' | '(' | ')' | '{' | '}' | '[' | ']' | '|').Returns (context => new Symbol(context));

            yield return
                new TestCaseData (
                    new Repeat(identifier | integerLiteral | symbol | whitespace),
                    "abc 1 2 adfbsd = x y 45",
                    new Token[] { new Identifier("abc"), new Whitespace(), new IntegerLiteral("1"), new IntegerLiteral("2"), new Identifier("adfbsd") }
                )
                    .SetName ("Lexer := { identifier | integer-literal | symbol }");
        }
    }
}
