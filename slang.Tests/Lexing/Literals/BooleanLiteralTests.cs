using NUnit.Framework;
using slang.Lexing;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class BooleanLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, IEnumerable<Token> expected)
        {
            var lexer = new Lexer (SlangGrammar.ToRule ());
            var result = lexer.Scan (input);
            result.ShouldBeEquivalentTo (expected);
        }

        static IEnumerable<TestCaseData> GetLiterals()
        {
            yield return new TestCaseData ("true", new Token [] { new BooleanLiteral ("true") })
                .SetName ("Given a lowercase 'true' When parsed Then a boolean literal is returned");
            
            yield return new TestCaseData ("false", new Token [] { new BooleanLiteral ("false") })
                .SetName ("Given lowercase 'false' When parsed Then a boolean literal is returned");
        }
    }
}

