using System;
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
        public void Given_a_punctuation_mark_as_a_string_When_parsed_Then_a_punctuation_token_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
        }

        static IEnumerable<TestCaseData> GetPunctuation()
        {
            yield return new TestCaseData ("&", typeof(Symbol), "&");
            yield return new TestCaseData ("\'", typeof(Symbol), "\'");
            yield return new TestCaseData ("*", typeof(Symbol), "*");
            yield return new TestCaseData ("@", typeof(Symbol), "@");
            yield return new TestCaseData ("\\", typeof(Symbol), "\\");
            yield return new TestCaseData ("^", typeof(Symbol), "^");
            yield return new TestCaseData (":", typeof(Symbol), ":");
            yield return new TestCaseData (",", typeof(Symbol), ",");
            yield return new TestCaseData ("$", typeof(Symbol), "$");
            yield return new TestCaseData (".", typeof(Symbol), ".");
            yield return new TestCaseData ("=", typeof(Symbol), "=");
            yield return new TestCaseData ("!", typeof(Symbol), "!");
            yield return new TestCaseData ("/", typeof(Symbol), "/");
            yield return new TestCaseData ("-", typeof(Symbol), "-");
            yield return new TestCaseData ("<", typeof(Symbol), "<");
            yield return new TestCaseData ("{", typeof(Symbol), "{");
            yield return new TestCaseData ("(", typeof(Symbol), "(");
            yield return new TestCaseData ("[", typeof(Symbol), "[");
            yield return new TestCaseData ("%", typeof(Symbol), "%");
            yield return new TestCaseData ("#", typeof(Symbol), "#");
            yield return new TestCaseData ("|", typeof(Symbol), "|");
            yield return new TestCaseData ("+", typeof(Symbol), "+");
            yield return new TestCaseData ("?", typeof(Symbol), "?");
            yield return new TestCaseData (">", typeof(Symbol), ">");
            yield return new TestCaseData ("}", typeof(Symbol), "}");
            yield return new TestCaseData (")", typeof(Symbol), ")");
            yield return new TestCaseData ("]", typeof(Symbol), "]");
            yield return new TestCaseData (";", typeof(Symbol), ";");
            yield return new TestCaseData ("~", typeof(Symbol), "~");
            yield return new TestCaseData ("_", typeof(Symbol), "_");
        }
    }
}

