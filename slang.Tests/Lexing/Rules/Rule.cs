using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace slang.Tests.Lexing.Rules
{
    abstract class Rule
    {
        public static Rule operator| (Rule left, Rule right)
        {
            return new OrRule(left, right);
        }

        public static Rule operator+ (Rule left, Rule right)
        {
            return new AndRule(left, right);
        }

        public static implicit operator Rule (string value)
        {
            return new ConstantRule(value);
        }
    }

    static class RuleExtensions
    {
        public static IEnumerable<Token> Analyze(this Rule rule, string input)
        {
            yield return new Token("START", "$");
            yield return new Token("END", "EOF");
        }
    }

    class Token
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Token(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    class ConstantRule : Rule
    {
        public ConstantRule(string value)
        {
        }
    }

    class ComplexRule
    {
        public ComplexRule(Rule rule)
        {

        }
    }

    class OrRule : Rule
    {
        public OrRule(Rule left, Rule right)
        {
        }
    }

    class AndRule : Rule
    {
        public AndRule(Rule left, Rule right)
        {
        }
    }
}
