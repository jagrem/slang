using NUnit.Framework;
using slang.Lexing;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;
using slang.Lexing.Tokens.Literals;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class CharacterLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, IEnumerable<Token> expected)
        {
            var lexer = new Lexer2 (SlangGrammar.ToRule ());
            var result = lexer.Scan (input);
            result.ShouldBeEquivalentTo (expected);
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
            yield return new TestCaseData ("'a'", new Token [] { new CharacterLiteral ("'a'") }).SetName ("Given a single character When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\''", new Token [] { new CharacterLiteral ("'\\'") }).SetName (@"Given an escape sequence '\'' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\\"'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\""' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\\\'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\\' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\0'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\0' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\a'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\a' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\b'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\b' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\f'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\f' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\n'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\n' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\r'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\r' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\t'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\t' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\v'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given an escape sequence '\v' When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a hexadecimal escape sequence with one digit When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3f'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a hexadecimal escape sequence with two digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3fb'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a hexadecimal escape sequence with three digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\x3fb6'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a hexadecimal escape sequence with four digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\u045f'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a unicode escape sequence with four digits When parsed Then a character literal is returned");
            yield return new TestCaseData ("'\\U045fe72c'", new Token [] { new CharacterLiteral ("'a'") }).SetName (@"Given a unicode escape sequence with eight digits When parsed Then a character literal is returned");
        }
    }
}

