using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class AndRuleExtensions
    {
        public static Tree Transform (this And rule)
        {
            var left = rule.Left.Transform ();
            var right = rule.Right.Transform ();
            var tree = left.AttachChild (right);

            if(rule.TokenCreator != null) {
                tree.Leaves
                    .ToList ()
                    .ForEach (node => node.Transitions [Character.Any] = new Transition (null, rule.TokenCreator));
            }

            return tree;
        }
    }
}

