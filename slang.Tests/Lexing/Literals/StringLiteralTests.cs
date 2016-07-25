using NUnit.Framework;
using slang.Lexing;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class StringLiteralTests
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
            //string-literal:
            //    regular-string-literal
            //    | verbatim-string-literal
            //regular-string-literal:
            //    "   regular-string-literal-charactersopt   "
            //regular-string-literal-characters:
            //    regular-string-literal-character
            //    | regular-string-literal-characters   regular-string-literal-character
            //regular-string-literal-character:
            //    single-regular-string-literal-character
            //    | simple-escape-sequence
            //    | hexadecimal-escape-sequence
            //    | unicode-escape-sequence
            //single-regular-string-literal-character:
            //    Any character except " (U+0022), \ (U+005C), and new-line-character
            //verbatim-string-literal:
            //    @"   verbatim -string-literal-charactersopt   "
            //verbatim-string-literal-characters:
            //    verbatim-string-literal-character
            //    | verbatim-string-literal-characters   verbatim-string-literal-character
            //verbatim-string-literal-character:
            //    single-verbatim-string-literal-character
            //    | quote-escape-sequence
            //single-verbatim-string-literal-character:
            //    Any character except "
            //quote-escape-sequence:
            //    ""
            yield return null;
        }

    }
}

