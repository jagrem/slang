using NUnit.Framework;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Tests.Lexing
{
    [TestFixture]
    public class KeywordTests
    {
        [TestCaseSource("GetKeywords")]
        public void Given_a_keyword_as_a_string_When_parsed_Then_a_keyword_type_is_returned(string input)
        {
            var result = Lexer.Analyze (input).ToArray ();

            result.ElementAt (1)
                .Should().BeOfType<Keyword> ()
                .Which.As<Keyword>()
                .Value.Should ().Be (input);
        }

        static IEnumerable<TestCaseData> GetKeywords()
        {
            yield return new TestCaseData("abstract");
            yield return new TestCaseData("as");
            yield return new TestCaseData("async");
            yield return new TestCaseData("await");
            yield return new TestCaseData("base");
            yield return new TestCaseData("bool");
            yield return new TestCaseData("break");
            yield return new TestCaseData("byte");
            yield return new TestCaseData("case");
            yield return new TestCaseData("catch");
            yield return new TestCaseData("char");
            yield return new TestCaseData("checked");
            yield return new TestCaseData("class");
            yield return new TestCaseData("continue");
            yield return new TestCaseData("decimal");
            yield return new TestCaseData("def");
            yield return new TestCaseData("default");
            yield return new TestCaseData("dynamic");
            yield return new TestCaseData("do");
            yield return new TestCaseData("double");
            yield return new TestCaseData("else");
            yield return new TestCaseData("enum");
            yield return new TestCaseData("extends");
            yield return new TestCaseData("finally");
            yield return new TestCaseData("fixed");
            yield return new TestCaseData("float");
            yield return new TestCaseData("for");
            yield return new TestCaseData("if");
            yield return new TestCaseData("implicit");
            yield return new TestCaseData("import");
            yield return new TestCaseData("in");
            yield return new TestCaseData("int");
            yield return new TestCaseData("internal");
            yield return new TestCaseData("is");
            yield return new TestCaseData("lock");
            yield return new TestCaseData("long");
            yield return new TestCaseData("match");
            yield return new TestCaseData("new");
            yield return new TestCaseData("object");
            yield return new TestCaseData("operator");
            yield return new TestCaseData("override");
            yield return new TestCaseData("package");
            yield return new TestCaseData("private");
            yield return new TestCaseData("protected");
            yield return new TestCaseData("readonly");
            yield return new TestCaseData("return");
            yield return new TestCaseData("sealed");
            yield return new TestCaseData("this");
            yield return new TestCaseData("throw");
            yield return new TestCaseData("trait");
            yield return new TestCaseData("try");
            yield return new TestCaseData("type");
            yield return new TestCaseData("val");
            yield return new TestCaseData("var");
            yield return new TestCaseData("while");
            yield return new TestCaseData("with");
            yield return new TestCaseData("yield");
        }
    }
}

