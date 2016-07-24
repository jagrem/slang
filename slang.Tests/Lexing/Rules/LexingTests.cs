using NUnit.Framework;
using slang.Lexing;
using slang.Lexing.Rules.Core;
using FluentAssertions;
using slang.Lexing.Tokens;
using System.Collections.Generic;
using System;
using System.Linq;
using slang.Lexing.Rules.Extensions;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    public class LexingTests
    {
        class Literal : Token { public Literal (string value) : base (value) { } }
        class FunctionName : Token { public FunctionName (string value) : base (value) { } }
        class Identifier : Token { public Identifier (string value) : base(value) {} }
        class IntegerLiteral : Token { public  IntegerLiteral(string value) : base (value) { } }
        class Operator : Token { public Operator (string value) : base (value) { } }
        class Whitespace : Token { public Whitespace () : base (" ") { } }
        class Keyword : Token { public Keyword(string value) : base(value) { } }

        [TestCaseSource("GetTestCases")]
        public void Given_valid_input_and_a_constant_rule_When_lexed_Then_the_correct_tokens_are_returned(Rule rule, string input, IEnumerable<Token> expectedTokens)
        {
            var lexer = new Lexer2 (rule);
            Console.WriteLine (lexer);
            var result = lexer.Scan (input);
            Console.WriteLine (string.Join ("\n", result.Select (r => "[" + r.GetType ().Name + " '" + r.Value + "']")));
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

            yield return new TestCaseData (
                new Repeat(new Range ('a', 'z')).Returns (literal),
                "acserzq",
                new [] { new Literal ("acserzq") })
                    .SetName ("Literal := { 'a'..'z' }");

            yield return new TestCaseData (
                new Repeat(new ConstantString("abstract")).Returns (context => new Keyword(context)),
                "abstract abstract xyz",
                new [] { new Keyword ("abstract"), new Keyword ("abstract") })
                    .SetName ("Keyword := { 'abstract' }");

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

            var uppercase = new Range('A', 'Z');
            var lowercase = new Range('a', 'z');
            var alpha = uppercase | lowercase;
            var numeric = new Range('0', '9');
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

            var op = ((Rule)'!' | '@' | '#' | '$' | '%' | '^' | '&' | '*' | '(' | ')' | '{' | '}' | '[' | ']' | '|' | '=').Returns (context => new Operator(context));
            var identifier = lowercase + new Repeat (lowercase | numeric).Returns (context => new Identifier(context));
            var integerLiteral = new Repeat (numeric).Returns (context => new IntegerLiteral (context));

            yield return
                new TestCaseData (
                    identifier | integerLiteral | op,
                    "abc 1 2 adfbsd = xs ys 45",
                    new Token[] { new Identifier("abc"), new IntegerLiteral("1"), new IntegerLiteral("2"), new Identifier("adfbsd"), new Operator("="), new Identifier("xs"), new Identifier("ys"), new IntegerLiteral("45") }
                )
                    .SetName ("Lexer := { identifier | integer-literal | operator }");
        }
    }
}
