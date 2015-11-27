using NUnit.Framework;
using System.Collections.Generic;
using slang.Lexing;
using System;
using System.Linq;
using FluentAssertions;
using slang.Lexing.Tokens.Literals;

namespace slang.Tests.Lexing.Literals
{
    [TestFixture]
    public class IntegerLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
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
            yield return new TestCaseData ("1234", typeof(IntegerLiteral), "1234").SetName ("Given decimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234L", typeof(IntegerLiteral), "1234l").SetName ("Given decimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234l", typeof(IntegerLiteral), "1234l").SetName ("Given decimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234ul", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Ul", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234UL", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234uL", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Lu", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234LU", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", typeof(IntegerLiteral), "1234ul").SetName ("Given decimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4e", typeof(IntegerLiteral), "0xa4e").SetName ("Given hexadecimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eL", typeof(IntegerLiteral), "0xa4el").SetName ("Given hexadecimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4el", typeof(IntegerLiteral), "0xa4el").SetName ("Given hexadecimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4eul", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUl", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUL", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4euL", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLu", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLU", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", typeof(IntegerLiteral), "0xa4eul").SetName ("Given hexadecimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
        }
    }
}

