using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules;
using slang.Lexing.Rules.Core;
using slang.Lexing.Rules.Extensions;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees
{
    public static class LexicalTreeBuilder
    {
        public static LexicalNode Build (Rule rule)
        {
            var start = new StartNode ();
            BuildTreeForRule (rule, new [] { start });
            return start;
        }

        static LexicalNode BuildTreeForRule(Rule rule, LexicalNode parent)
        {
            return BuildTreeForRule (rule, new [] { parent });
        }

        static LexicalNode BuildTreeForRule (Rule rule, IEnumerable<LexicalNode> parents)
        {
            if (rule is OrRule) {
                return GetTreeForOrRule (rule as OrRule, parents.Single ());
            }

            if (rule is AndRule) {
                return GetTreeForAndRule (rule as AndRule, parents.Single ());
            }

            return GetTreeForConstantRule (rule as ConstantRule, parents);
        }

        static LexicalNode GetTreeForAndRule (AndRule rule, LexicalNode parent)
        {
            var left = BuildTreeForRule (rule.Left, parent);
            BuildTreeForRule (rule.Right, GetLeafNodes (left));
            return left;
        }

        static LexicalNode GetTreeForConstantRule (ConstantRule rule, IEnumerable<LexicalNode> parents)
        {
            var node = new LexicalNode ();
            var value = rule.Value;

            foreach (var p in parents) {
                if (!p.Transitions.ContainsKey (value)) {
                    p.Transitions.Add (value, node);
                }
            }

            return node;
        }

        static LexicalNode GetTreeForOptionRule(OptionRule rule, LexicalNode parent)
        {
            var option = BuildTreeForRule (rule.Option, parent);
            return option;
        }

        static LexicalNode GetTreeForOrRule (OrRule rule, LexicalNode parent)
        {
            BuildTreeForRule (rule.Left, parent);
            BuildTreeForRule (rule.Right, parent);
            return parent;
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

