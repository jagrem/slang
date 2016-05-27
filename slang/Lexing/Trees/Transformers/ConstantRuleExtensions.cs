using System.Collections.Generic;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;
using System.Linq;

namespace slang.Lexing.Trees.Transformers
{
    public static class ConstantRuleExtensions
    {
        public static Node Transform (this Constant rule, IEnumerable<Node> parents)
        {
            var node = new Node ();
            var value = rule.Value;
            parents
                .Where (parent => !parent.Transitions.ContainsKey (value))
                .ToList ().ForEach (parent => parent.Transitions.Add (rule.Value, node));
            return node;
        }
    }
}
