using NUnit.Framework;
using slang.Lexing;
using slang.Lexing.Rules.Core;
using FluentAssertions;
using slang.Lexing.Tokens;
using System.Collections.Generic;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    public class LexingTests
    {
        class Literal : Token { }

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
    

        IEnumerable<TestCaseData> GetTestCases()
        {
            yield return
                new TestCaseData (
                ((Rule)'a').Returns (() => new Literal ()),
                "a",
                new [] { new Literal () })
                    .SetName (GetTestCaseName ("Literal := 'a'","a"));
            
            yield return new TestCaseData (
                ((Rule)'a' + 'b').Returns (() => new Literal ()),
                "ab",
                new [] { new Literal () })
                    .SetName(GetTestCaseName ("Literal := 'a' 'b'", "ab"));
            
            yield return new TestCaseData (
                ((Rule)'a' | 'b').Returns (() => new Literal ()),
                "a",
                new [] { new Literal () })
                    .SetName ("Literal := 'a' | 'b'");

            yield return new TestCaseData (
                ('a' + ((Rule)'b' | 'c') + 'd').Returns (() => new Literal ()),
                "acd",
                new [] { new Literal () })
                    .SetName ("Literal := 'a' ('b' | 'c') 'd'");

            yield return new TestCaseData (
                new Repeat('a').Returns (() => new Literal ()),
                "aaaa",
                new [] { new Literal () })
                    .SetName ("Literal := { 'a' }");

            yield return new TestCaseData (
                new Repeat ((Rule)'a' | 'b').Returns (() => new Literal ()),
                "abab",
                new [] { new Literal () })
                    .SetName ("Literal := { 'a' | 'b' }");

            yield return new TestCaseData (
                ((Rule)'a' | 'b').Returns (() => new Literal ()),
                "acacb",
                new [] { new Literal (), new Literal (), new Literal () })
                    .SetName ("Literal := 'a' | 'b'");

            var digits = (Rule)'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';
            var upperCaseHexadecimal = (Rule)'A' | 'B' | 'C' | 'D' | 'E' | 'F';
            var lowerCaseHexadecimal = (Rule)'a' | 'b' | 'c' | 'd' | 'e' | 'f';
            var initialCharacter = upperCaseHexadecimal | digits;
            var medialCharacter = lowerCaseHexadecimal | digits;
            var finalCharacter = upperCaseHexadecimal | digits;

                yield return new TestCaseData (
                (initialCharacter + new Repeat(medialCharacter) + finalCharacter).Returns (() => new Literal ()),
                "Ac02feD",
                new [] { new Literal () })
                    .SetName ("Literal := hex");

        }
    }
}
