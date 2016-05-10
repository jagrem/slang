using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    class RuleTests
    {
        [Test]
        public void When_exploring_the_concept_of_a_rule_Then_it_should_be_awesome()
        {
            var rule = (Rule) "a" | "b" | "c";
            var result = rule.Analyze("abc");
            result.ShouldBeEquivalentTo(new Token("START","$"), new Token("END","EOF");
        }
    }
}
