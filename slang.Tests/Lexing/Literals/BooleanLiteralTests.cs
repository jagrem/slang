using NUnit.Framework;
using slang.Lexing;
using System;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Literals;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class BooleanLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
        }

        static IEnumerable<TestCaseData> GetLiterals()
        {
            
            yield return new TestCaseData ("true", typeof(BooleanLiteral), "true").SetName ("Given a lowercase 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData ("True", typeof(BooleanLiteral), "true").SetName ("Given capitalized 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData ("TRUE", typeof(BooleanLiteral), "true").SetName ("Given an all uppercase 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData ("false", typeof(BooleanLiteral), "false").SetName ("Given lowercase 'false' When parsed Then a boolean literal is returned");
            yield return new TestCaseData ("False", typeof(BooleanLiteral), "false").SetName ("Given capitalized 'false' When parsed Then a boolean literal is returned");
            yield return new TestCaseData ("FALSE", typeof(BooleanLiteral), "false").SetName ("Given an all uppercase 'false' When parsed Then a boolean literal is returned");
        }
    }
}

