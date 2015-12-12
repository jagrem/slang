using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing
{
    [TestFixture]
    public class IdentifierTests
    {
        [TestCaseSource("GetIdentifiers")]
        public void Given_an_identifier_as_a_string_When_parsed_Then_an_identifier_token_is_returned(string input)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ElementAt (1)
                .Should().BeOfType<Identifier> ()
                .Which.As<Identifier>()
                .Value.Should ().Be (input);
        }

        //identifier:
        //    available-identifier
        //    @   identifier-or-keyword
        //available-identifier:
        //    An identifier-or-keyword that is not a keyword
        //identifier-or-keyword:
        //    identifier-start-character   identifier-part-charactersopt
        //identifier-start-character:
        //    letter-character
        //    _ (the underscore character U+005F)
        //identifier-part-characters:
        //    identifier-part-character
        //    identifier-part-characters   identifier-part-character
        //identifier-part-character:
        //    letter-character
        //    decimal-digit-character
        //    connecting-character
        //    combining-character
        //    formatting-character
        //letter-character:
        //    A Unicode character of classes Lu, Ll, Lt, Lm, Lo, or Nl
        //    A unicode-escape-sequence representing a character of classes Lu, Ll, Lt, Lm, Lo, or Nl
        //    combining-character:
        //    A Unicode character of classes Mn or Mc
        //    A unicode-escape-sequence representing a character of classes Mn or Mc
        //decimal-digit-character:
        //    A Unicode character of the class Nd
        //    A unicode-escape-sequence representing a character of the class Nd
        //connecting-character:
        //    A Unicode character of the class Pc
        //    A unicode-escape-sequence representing a character of the class Pc
        //formatting-character:
        //    A Unicode character of the class Cf
        //    A unicode-escape-sequence representing a character of the class Cf
        static IEnumerable<TestCaseData> GetIdentifiers()
        {
            yield return new TestCaseData ("_");
        }
    }
}

