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
            if (rule is Or) {
                return GetTreeForOrRule (rule as Or, parents.Single ());
            }

            if (rule is And) {
                return GetTreeForAndRule (rule as And, parents.Single ());
            }

            return GetTreeForConstantRule (rule as Constant, parents);
        }

        static LexicalNode GetTreeForAndRule (And rule, LexicalNode parent)
        {
            var left = BuildTreeForRule (rule.Left, parent);
            BuildTreeForRule (rule.Right, GetLeafNodes (left));
            return left;
        }

        static LexicalNode GetTreeForConstantRule (Constant rule, IEnumerable<LexicalNode> parents)
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

        static LexicalNode GetTreeForOptionRule(Option rule, LexicalNode parent)
        {
            var option = BuildTreeForRule (rule.Value, parent);
            return option;
        }

        static LexicalNode GetTreeForOrRule (Or rule, LexicalNode parent)
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

