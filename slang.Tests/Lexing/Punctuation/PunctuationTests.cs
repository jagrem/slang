using System;
using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Punctuation;

namespace slang.Tests.Lexing.Punctuation
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
            yield return new TestCaseData ("&", typeof(Ampersand), "&");
            yield return new TestCaseData ("\'", typeof(Apostrophe), "\'");
            yield return new TestCaseData ("*", typeof(Asterisk), "*");
            yield return new TestCaseData ("@", typeof(At), "@");
            yield return new TestCaseData ("\\", typeof(BackSlash), "\\");
            yield return new TestCaseData ("^", typeof(Caret), "^");
            yield return new TestCaseData (":", typeof(Colon), ":");
            yield return new TestCaseData (",", typeof(Comma), ",");
            yield return new TestCaseData ("$", typeof(DollarSign), "$");
            yield return new TestCaseData (".", typeof(Dot), ".");
            yield return new TestCaseData ("=", typeof(Equals), "=");
            yield return new TestCaseData ("!", typeof(ExclamationMark), "!");
            yield return new TestCaseData ("/", typeof(ForwardSlash), "/");
            yield return new TestCaseData ("-", typeof(Hyphen), "-");
            yield return new TestCaseData ("<", typeof(LeftAngleBracket), "<");
            yield return new TestCaseData ("{", typeof(LeftBrace), "{");
            yield return new TestCaseData ("(", typeof(LeftParenthesis), "(");
            yield return new TestCaseData ("[", typeof(LeftSquareBracket), "[");
            yield return new TestCaseData ("%", typeof(Modulus), "%");
            yield return new TestCaseData ("#", typeof(Octothorpe), "#");
            yield return new TestCaseData ("|", typeof(Pipe), "|");
            yield return new TestCaseData ("+", typeof(Plus), "+");
            yield return new TestCaseData ("?", typeof(QuestionMark), "?");
            yield return new TestCaseData (">", typeof(RightAngleBracket), ">");
            yield return new TestCaseData ("}", typeof(RightBrace), "}");
            yield return new TestCaseData (")", typeof(RightParenthesis), ")");
            yield return new TestCaseData ("]", typeof(RightSquareBracket), "]");
            yield return new TestCaseData (";", typeof(Semicolon), ";");
            yield return new TestCaseData ("~", typeof(Tilde), "~");
            yield return new TestCaseData ("_", typeof(Underscore), "_");
        }
    }
}

