using System.Collections.Generic;
using System.Linq;

namespace slang.Lexing.Rules
{
    public static class LexicalTreeBuilder
    {
        public static LexicalNode Build (Rule rule)
        {
            var start = new StartNode ();
            GetTreeForRule (rule, new [] { start });
            return start;
        }

        static LexicalNode GetTreeForRule (Rule rule, IEnumerable<LexicalNode> parents)
        {
            if (rule is OrRule) {
                return GetTreeForOrRule (rule as OrRule, parents.First ());
            }

            if (rule is AndRule) {
                return GetTreeForAndRule (rule as AndRule, parents.First ());
            }

            return GetTreeForConstantRule (rule as ConstantRule, parents);
        }

        static LexicalNode GetTreeForAndRule (AndRule rule, LexicalNode parent)
        {
            GetTreeForRule (rule.Right, GetLeafNodes (GetTreeForRule (rule.Left, new [] { parent })));
            return parent;
        }

        static LexicalNode GetTreeForConstantRule (ConstantRule rule, IEnumerable<LexicalNode> parents)
        {
            var node = new LexicalNode ();
            var value = rule.Value;

            foreach (var p in parents) {
                p.Transitions.Add (new LexicalTransition (value, node));
            }

            return node;
        }

        static LexicalNode GetTreeForOrRule (OrRule rule, LexicalNode parent)
        {
            GetTreeForRule (rule.Left, new [] { parent });
            GetTreeForRule (rule.Right, new [] { parent });
            return parent;
        }

        static IEnumerable<LexicalNode> GetLeafNodes (LexicalNode node)
        {
            if (!node.Transitions.Any ()) {
                return new [] { node };
            }

            return node.Transitions.SelectMany (n => {
                if (!n.Target.Transitions.Any ()) {
                    return new [] { n.Target };
                } else {
                    return GetLeafNodes (n.Target);
                }
            });
        }


    }
}

