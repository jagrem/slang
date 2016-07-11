using slang.Lexing.Rules.Core;
using System.Linq;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OrRuleExtensions
    {
        public static Tree Transform(this Or rule)
        {
            var left = rule.Left.Transform ();
            var right = rule.Right.Transform ();
            var tree = left.Merge (right);

            tree
                .Leaves
                .ToList ()
                .ForEach (leaf => leaf.Transitions[Character.Any] = new Transition(null, rule.TokenCreator));

            return tree;
        }
    }
}
