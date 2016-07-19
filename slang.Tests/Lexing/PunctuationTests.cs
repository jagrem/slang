using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing
{
    [TestFixture]
    public class PunctuationTests
    {
        [TestCaseSource("GetPunctuation")]
        public void Given_a_punctuation_mark_as_a_string_When_parsed_Then_a_punctuation_token_is_returned(string input)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ElementAt (1)
                .Should().BeOfType<Symbol> ()
                .Which.As<Symbol>()
                .Value.Should ().Be (input);
        }

        static IEnumerable<TestCaseData> GetPunctuation()
        {
            yield return new TestCaseData ("&");
            yield return new TestCaseData ("*");
            yield return new TestCaseData ("@");
            yield return new TestCaseData ("\\");
            yield return new TestCaseData ("^");
            yield return new TestCaseData (":");
            yield return new TestCaseData (",");
            yield return new TestCaseData ("$");
            yield return new TestCaseData (".");
            yield return new TestCaseData ("=");
            yield return new TestCaseData ("!");
            yield return new TestCaseData ("/");
            yield return new TestCaseData ("-");
            yield return new TestCaseData ("<");
            yield return new TestCaseData ("{");
            yield return new TestCaseData ("(");
            yield return new TestCaseData ("[");
            yield return new TestCaseData ("%");
            yield return new TestCaseData ("#");
            yield return new TestCaseData ("|");
            yield return new TestCaseData ("+");
            yield return new TestCaseData ("?");
            yield return new TestCaseData (">");
            yield return new TestCaseData ("}");
            yield return new TestCaseData (")");
            yield return new TestCaseData ("]");
            yield return new TestCaseData (";");
            yield return new TestCaseData ("~");
            yield return new TestCaseData ("_");
        }
    }
}

