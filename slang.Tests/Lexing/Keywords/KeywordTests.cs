using NUnit.Framework;
using System;
using slang.Lexing;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using slang.Lexing.Tokens.Keywords;

namespace slang.Tests.Lexing.Keywords
{
    [TestFixture]
    public class KeywordTests
    {
        [TestCaseSource("GetKeywords")]
        public void Given_a_keyword_as_a_string_When_parsed_Then_a_keyword_type_is_returned(string input, Type expectedType, string expectedValue)
        {
            var result = Lexer.Analyze (input).ToArray ();
            result.ShouldBeEquivalentTo (new[] { new { Value = "$" }, new { Value = expectedValue }, new { Value = "EOF" } });
            result[1].Should ().BeOfType(expectedType);
        }

        static IEnumerable<TestCaseData> GetKeywords()
        {
            yield return new TestCaseData("abstract", typeof(Keyword), "abstract");
            yield return new TestCaseData("as", typeof(Keyword), "as");
            yield return new TestCaseData("async", typeof(Keyword), "async");
            yield return new TestCaseData("await", typeof(Keyword), "await");
            yield return new TestCaseData("base", typeof(Keyword), "base");
            yield return new TestCaseData("bool", typeof(Keyword), "bool");
            yield return new TestCaseData("break", typeof(Keyword), "break");
            yield return new TestCaseData("byte", typeof(Keyword), "byte");
            yield return new TestCaseData("case", typeof(Keyword), "case");
            yield return new TestCaseData("catch", typeof(Keyword), "catch");
            yield return new TestCaseData("char", typeof(Keyword), "char");
            yield return new TestCaseData("checked", typeof(Keyword), "checked");
            yield return new TestCaseData("class", typeof(Keyword), "class");
            yield return new TestCaseData("continue", typeof(Keyword), "continue");
            yield return new TestCaseData("decimal", typeof(Keyword), "decimal");
            yield return new TestCaseData("def", typeof(Keyword), "def");
            yield return new TestCaseData("default", typeof(Keyword), "default");
            yield return new TestCaseData("dynamic", typeof(Keyword), "dynamic");
            yield return new TestCaseData("do", typeof(Keyword), "do");
            yield return new TestCaseData("double", typeof(Keyword), "double");
            yield return new TestCaseData("else", typeof(Keyword), "else");
            yield return new TestCaseData("enum", typeof(Keyword), "enum");
            yield return new TestCaseData("extends", typeof(Keyword), "extends");
            yield return new TestCaseData("finally", typeof(Keyword), "finally");
            yield return new TestCaseData("fixed", typeof(Keyword), "fixed");
            yield return new TestCaseData("float", typeof(Keyword), "float");
            yield return new TestCaseData("for", typeof(Keyword), "for");
            yield return new TestCaseData("if", typeof(Keyword), "if");
            yield return new TestCaseData("implicit", typeof(Keyword), "implicit");
            yield return new TestCaseData("import", typeof(Keyword), "import");
            yield return new TestCaseData("in", typeof(Keyword), "in");
            yield return new TestCaseData("int", typeof(Keyword), "int");
            yield return new TestCaseData("internal", typeof(Keyword), "internal");
            yield return new TestCaseData("is", typeof(Keyword), "is");
            yield return new TestCaseData("lock", typeof(Keyword), "lock");
            yield return new TestCaseData("long", typeof(Keyword), "long");
            yield return new TestCaseData("match", typeof(Keyword), "match");
            yield return new TestCaseData("new", typeof(Keyword), "new");
            yield return new TestCaseData("object", typeof(Keyword), "object");
            yield return new TestCaseData("operator", typeof(Keyword), "operator");
            yield return new TestCaseData("override", typeof(Keyword), "override");
            yield return new TestCaseData("package", typeof(Keyword), "package");
            yield return new TestCaseData("private", typeof(Keyword), "private");
            yield return new TestCaseData("protected", typeof(Keyword), "protected");
            yield return new TestCaseData("readonly", typeof(Keyword), "readonly");
            yield return new TestCaseData("return", typeof(Keyword), "return");
            yield return new TestCaseData("sealed", typeof(Keyword), "sealed");
            yield return new TestCaseData("this", typeof(Keyword), "this");
            yield return new TestCaseData("throw", typeof(Keyword), "throw");
            yield return new TestCaseData("trait", typeof(Keyword), "trait");
            yield return new TestCaseData("try", typeof(Keyword), "try");
            yield return new TestCaseData("type", typeof(Keyword), "type");
            yield return new TestCaseData("val", typeof(Keyword), "val");
            yield return new TestCaseData("var", typeof(Keyword), "var");
            yield return new TestCaseData("while", typeof(Keyword), "while");
            yield return new TestCaseData("with", typeof(Keyword), "with");
            yield return new TestCaseData("yield", typeof(Keyword), "yield");
        }
    }
}

