using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class AndRuleExtensions
    {
        public static Node Transform (this And rule, Node parent)
        {
            var left = rule.Left.Transform (parent);
            rule.Right.Transform (GetLeafNodes (left));
            return left;
        }

        static IEnumerable<Node> GetLeafNodes (Node node)
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

