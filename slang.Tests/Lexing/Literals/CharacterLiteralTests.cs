using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Literals;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class CharacterLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input)
        {
            var result = Lexer.Analyze (input).ToArray ();

            result.ElementAt (1)
                .Should().BeOfType<CharacterLiteral> ()
                .Which.As<CharacterLiteral>()
                .Value.Should ().Be (input);
        }

        static IEnumerable<TestCaseData> GetLiterals()
        {
            //  character-literal:
            //      ' character '
            //  character:
            //      single-character
            //      simple-escape-sequence
            //      hexadecimal-escape-sequence
            //      unicode-escape-sequence
            //  single-character:
            //      Any character except ' (U+0027), \ (U+005C), and new-line-character
            //  simple-escape-sequence:
            //      \' | \" | \\ | \0 | \a | \b | \f | \n | \r | \t | \v
            //  hexadecimal-escape-sequence:
            //      \x  hex-digit [ hex-digit ] [ hex-digit ] [ hex-digit ]
            //  unicode-escape-sequence:
            //      \u   hex-digit   hex-digit   hex-digit   hex-digit
            //      | \U   hex-digit   hex-digit   hex-digit   hex-digit   hex-digit   hex-digit   hex-digit   hex-digit
            yield return new TestCaseData ("'a'").SetName ("Given a single character When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\''").SetName (@"Given an escape sequence '\'' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\\"'").SetName (@"Given an escape sequence '\""' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\\\'").SetName (@"Given an escape sequence '\\' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\0'").SetName (@"Given an escape sequence '\0' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\a'").SetName (@"Given an escape sequence '\a' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\b'").SetName (@"Given an escape sequence '\b' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\f'").SetName (@"Given an escape sequence '\f' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\n'").SetName (@"Given an escape sequence '\n' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\r'").SetName (@"Given an escape sequence '\r' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\t'").SetName (@"Given an escape sequence '\t' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\v'").SetName (@"Given an escape sequence '\v' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3'").SetName (@"Given a hexadecimal escape sequence with one digit When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3f'").SetName (@"Given a hexadecimal escape sequence with two digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3fb'").SetName (@"Given a hexadecimal escape sequence with three digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3fb6'").SetName (@"Given a hexadecimal escape sequence with four digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\u045f'").SetName (@"Given a unicode escape sequence with four digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\U045fe72c'").SetName (@"Given a unicode escape sequence with eight digits When parsed Then a character literal is returned");
        }
    }
}

