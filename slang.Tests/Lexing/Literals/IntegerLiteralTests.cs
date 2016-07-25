using NUnit.Framework;
using System.Collections.Generic;
using slang.Lexing;
using FluentAssertions;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class IntegerLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, IEnumerable<Token> expected)
        {
            var lexer = new Lexer (SlangGrammar.ToRule ());
            var result = lexer.Scan (input);
            result.ShouldBeEquivalentTo (expected);
        }

        static IEnumerable<TestCaseData> GetLiterals() {
            // integer-literal:
            //    decimal-integer-literal
            //    | hexadecimal-integer-literal
            // decimal-integer-literal:
            //    decimal-digits <integer-type-suffix>
            // decimal-digits:
            //    decimal-digit
            //    decimal-digits decimal-digit
            // decimal-digit:
            //    0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
            // integer-type-suffix:
            //    U | u | L | l | UL | Ul | uL | ul | LU | Lu | lU | lu
            // hexadecimal-integer-literal:
            //    0x hex-digits <integer-type-suffix>
            //    0X hex-digits <integer-type-suffix>
            // hex-digits:
            //    hex-digit
            //    hex-digits hex-digit
            // hex-digit:
            //    0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | A | B | C | D | E | F | a | b | c | d | e | f
            yield return new TestCaseData ("1234", new Token [] { new IntegerLiteral ("1234") }).SetName ("Given decimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234L", new Token [] { new IntegerLiteral ("1234l") }).SetName ("Given decimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234l", new Token [] { new IntegerLiteral ("1234l") }).SetName ("Given decimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234ul", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Ul", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234UL", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234uL", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Lu", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234LU", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", new Token [] { new IntegerLiteral ("1234ul") }).SetName ("Given decimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4e", new Token [] { new IntegerLiteral ("0xa4e") }).SetName ("Given hexadecimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eL", new Token [] { new IntegerLiteral ("0xa4el") }).SetName ("Given hexadecimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4el", new Token [] { new IntegerLiteral ("0xa4el") }).SetName ("Given hexadecimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4eul", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUl", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUL", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4euL", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLu", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLU", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", new Token [] { new IntegerLiteral ("0xa4eul") }).SetName ("Given hexadecimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
        }
    }
}

