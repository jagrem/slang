using NUnit.Framework;
using System;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Keywords;

namespace slang.Tests.Lexing.Keywords
{
    [TestFixture]
    public class KeywordTests
    {
        [TestCaseSource("GetKeywords")]
        public void Given_a_keyword_as_a_string_When_parsed_Then_a_keyword_type_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
        }

        static IEnumerable<TestCaseData> GetKeywords()
        {
            yield return new TestCaseData ("catch", typeof(Keyword), "catch");
            yield return new TestCaseData ("class", typeof(Keyword), "class");
            yield return new TestCaseData ("def", typeof(Keyword), "def");
            yield return new TestCaseData ("dynamic", typeof(Keyword), "dynamic");
        }
    }
}

