using System;
using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Literals;

namespace slang.Tests.Parsing.Literals
{
    [TestFixture]
    public class RealLiteralTests
    {
        [TestCaseSource("GetLiterals")]
        public void Given_a_literal_as_a_string_When_parsed_Then_a_literal_type_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
        }

        static IEnumerable<TestCaseData> GetLiterals() {
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
            yield return new TestCaseData ("12345d", typeof(RealLiteral), "12345d").SetName ("Given digits and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("115436D", typeof(RealLiteral), "115436d").SetName ("Given digits and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData("1.653", typeof(RealLiteral), "1.653d").SetName ("Given digits with a dot When parsed Then a real literal is returned");
            yield return new TestCaseData("1.653d", typeof(RealLiteral), "1.653d").SetName ("Given digits with a dot and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData("1.23D", typeof(RealLiteral), "1.23d").SetName ("Given digits with a dot and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e12", typeof(RealLiteral), "7e+12d").SetName ("Given digits with an exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e+12", typeof(RealLiteral), "7e+12d").SetName ("Given digits with a positive exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("7e-12", typeof(RealLiteral), "7e-12d").SetName ("Given digits with a negative exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e13D", typeof(RealLiteral), "6e+13d").SetName ("Given digits with an exponent and an uppercase type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e+13D", typeof(RealLiteral), "6e+13d").SetName ("Given digits with a positive exponent and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("6e-13D", typeof(RealLiteral), "6e-13d").SetName ("Given digits with a negative exponent and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e9d", typeof(RealLiteral), "8e+9d").SetName ("Given digits with an exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e+9d", typeof(RealLiteral), "8e+9d").SetName ("Given digits with a positive exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("8e-9d", typeof(RealLiteral), "8e-9d").SetName ("Given digits with a negative exponent and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData (".04", typeof(RealLiteral), "0.04d").SetName ("Given digits with a leading dot When parsed Then a real literal is returned");
            yield return new TestCaseData (".04D", typeof(RealLiteral), "0.04d").SetName ("Given digits with a leading dot and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData (".04d", typeof(RealLiteral), "0.04d").SetName ("Given digits with a leading dot and a lowercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and an exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and a positive exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4", typeof(RealLiteral), "1.23e-4d").SetName ("Given digits with a dot and a negative exponent When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4D", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and an exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4D", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and a positive exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4D", typeof(RealLiteral), "1.23e-4d").SetName ("Given digits with a dot and a negative exponent and an uppercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e4d", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and an exponent and a lowercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e+4d", typeof(RealLiteral), "1.23e+4d").SetName ("Given digits with a dot and a positive exponent and a lowercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData ("1.23e-4d", typeof(RealLiteral), "1.23e-4d").SetName ("Given digits with a dot and a negative exponent and a lowercase double type suffix  When parsed Then a real literal is returned");
            yield return new TestCaseData (".04e2", typeof(RealLiteral), "0.04e+2d").SetName ("Given digits with a leading dot and an exponent When parsed Then a real literal is returned");
            yield return new TestCaseData (".04e2D", typeof(RealLiteral), "0.04e+2d").SetName ("Given digits with a leading dot and an exponent and an uppercase double type suffix When parsed Then a real literal is returned");
            yield return new TestCaseData (".04e-2d", typeof(RealLiteral), "0.04e-2d").SetName ("Given digits with a leading dot and a negative exponent a lowercase double type suffix When parsed Then a real literal is returned");
        }
     }
}

