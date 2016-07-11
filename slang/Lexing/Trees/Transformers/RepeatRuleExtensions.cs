using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class RepeatRuleExtensions
    {
        public static Tree Transform (this Repeat rule)
        {
            var tree = rule.Value.Transform ();
            var transitions = tree.Root.Transitions;

            tree.Leaves
                .ToList ()
                .ForEach (leaf => {
                    transitions.ToList ().ForEach (transition => leaf.Transitions.Add (transition.Key, transition.Value));
                    leaf.Transitions [Character.Any] = new Transition (null, rule.TokenCreator);
                });

            return tree;
        }
    }
}

