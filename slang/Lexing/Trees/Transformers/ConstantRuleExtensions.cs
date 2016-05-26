using System.Collections.Generic;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;
using System.Linq;

namespace slang.Lexing.Trees.Transformers
{
    public static class ConstantRuleExtensions
    {
        public static LexicalNode Transform (this Constant rule, IEnumerable<LexicalNode> parents)
        {
            var node = new LexicalNode ();
            var value = rule.Value;
            parents
                .Where (parent => parent.Transitions.ContainsKey (value))
                .ToList ().ForEach (parent => parent.Transitions.Add (rule.Value, node));
            return node;
        }
    }
}
