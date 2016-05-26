using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class AndRuleExtensions
    {
        public static LexicalNode Transform (this And rule, LexicalNode parent)
        {
            var left = rule.Left.Transform (parent);
            rule.Right.Transform (GetLeafNodes (left));
            return left;
        }

        static IEnumerable<LexicalNode> GetLeafNodes (LexicalNode node)
        {
            if (!node.Transitions.Any ()) {
                return new [] { node };
            }

            return node.Transitions.SelectMany (n => {
                if (!n.Value.Transitions.Any ()) {
                    return new [] { n.Value };
                } else {
                    return GetLeafNodes (n.Value);
                }
            });
        }
    }
}

