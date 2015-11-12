using System;
using NUnit.Framework;
using System.Collections.Generic;
using slang.Parsing.Lexing;
using System.Linq;
using FluentAssertions;

namespace slang.Tests.Parsing.Literals
{
    [TestFixture]
    public class LiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, Type expectedType)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.Should ().HaveCount (3);
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = input }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
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
    


            yield return new TestCaseData("true", typeof(BooleanLiteral)).SetName("Given a lowercase 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData("True", typeof(BooleanLiteral)).SetName("Given capitalized 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData("TRUE", typeof(BooleanLiteral)).SetName("Given an all uppercase 'true' When parsed Then a boolean literal is returned");
            yield return new TestCaseData("false", typeof(BooleanLiteral)).SetName("Given lowercase 'false' When parsed Then a boolean literal is returned");
            yield return new TestCaseData("False", typeof(BooleanLiteral)).SetName("Given capitalized 'false' When parsed Then a boolean literal is returned");
            yield return new TestCaseData("FALSE", typeof(BooleanLiteral)).SetName("Given an all uppercase 'false' When parsed Then a boolean literal is returned");

            // real-literal:
            //      decimal-digits "." decimal-digits <exponent-part> <real-type-suffix>
            //      | "." decimal-digits <exponent-part>   <real-type-suffix>
            //      | decimal-digits exponent-part <real-type-suffix>
            //      | decimal-digits real-type-suffix
            // exponent-part:
            //      "e"   <sign> decimal-digits
            //      | "E"  <sign> decimal-digits
            // sign:
            //      "+" | "-"
            // real-type-suffix:
            //      F | f | D | d | M | m
            yield return new TestCaseData ("12345d", typeof(RealLiteral)).SetName ("Given digits and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("115436D", typeof(RealLiteral)).SetName ("Given digits and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData("1.653", typeof(RealLiteral)).SetName ("Given digits with a dot When parsed Then a real literal is returned");
            yield return new TestCaseData("1.653d", typeof(RealLiteral)).SetName ("Given digits with a dot and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData("1.23D", typeof(RealLiteral)).SetName ("Given digits with a dot and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e12", typeof(RealLiteral)).SetName ("Given digits with an exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e+12", typeof(RealLiteral)).SetName ("Given digits with a positive exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e-12", typeof(RealLiteral)).SetName ("Given digits with a negative exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e13D", typeof(RealLiteral)).SetName ("Given digits with an exponent and an uppercase type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e+13D", typeof(RealLiteral)).SetName ("Given digits with a positive exponent and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e-13D", typeof(RealLiteral)).SetName ("Given digits with a negative exponent and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e9d", typeof(RealLiteral)).SetName ("Given digits with an exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e+9d", typeof(RealLiteral)).SetName ("Given digits with a positive exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e-9d", typeof(RealLiteral)).SetName ("Given digits with a negative exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData (".04", typeof(RealLiteral)).SetName ("Given digits with a leading dot When parsed Then a real literal is returned");
            yield return new TestCaseData (".04D", typeof(RealLiteral)).SetName ("Given digits with a leading dot and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData (".04d", typeof(RealLiteral)).SetName ("Given digits with a leading dot and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4", typeof(RealLiteral)).SetName ("Given digits with a dot and an exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4", typeof(RealLiteral)).SetName ("Given digits with a dot and a positive exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4", typeof(RealLiteral)).SetName ("Given digits with a dot and a negative exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4D", typeof(RealLiteral)).SetName ("Given digits with a dot and an exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4D", typeof(RealLiteral)).SetName ("Given digits with a dot and a positive exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4D", typeof(RealLiteral)).SetName ("Given digits with a dot and a negative exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4d", typeof(RealLiteral)).SetName ("Given digits with a dot and an exponent and a lowercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4d", typeof(RealLiteral)).SetName ("Given digits with a dot and a positive exponent and a lowercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4d", typeof(RealLiteral)).SetName ("Given digits with a dot and a negative exponent and a lowercase double type suffix  When parsed Then a real literal is returned");

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
            yield return new TestCaseData ("1234", typeof(IntegerLiteral)).SetName ("Given decimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234L", typeof(IntegerLiteral)).SetName ("Given decimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234l", typeof(IntegerLiteral)).SetName ("Given decimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("1234ul", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Ul", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234UL", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234uL", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234Lu", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234LU", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("1234lu", typeof(IntegerLiteral)).SetName ("Given decimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4e", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eL", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and lowercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4el", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and uppercase long type suffix When parsed Then a integer literal is returned");
            yield return new TestCaseData ("0xa4eul", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUl", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'Ul' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eUL", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'UL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4euL", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'uL' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLu", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'Lu' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4eLU", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'LU' type suffix When parsed Then an integer literal is returned");
            yield return new TestCaseData ("0xa4elu", typeof(IntegerLiteral)).SetName ("Given hexadecimal digits and 'lU' type suffix When parsed Then an integer literal is returned");
        }
    }
}

