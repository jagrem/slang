using System.Collections.Generic;
using slang.Lexing.Trees.Nodes;
using System.Linq;
using System;

namespace slang.Lexing.Trees
{
    public static class TreeDescriber
    {
        public static string Describe(TreeNode node)
        {
            int count = 0;
            return string.Join(
                Environment.NewLine, 
                GetAllNodes (node)
                .Select (n => string.Format (
                    "Node {0}{1} [{2}]",
                    count++,
                    n.IsTerminal ? "(terminal)" : string.Empty,
                    string.Join(",", n.Transitions.Select(t => "[" + t.Key.Value + "]"))
                                  )));
        }

        static IEnumerable<TreeNode> GetAllNodes(TreeNode node)
        {
            var seen = new List<TreeNode> ();
            var stack = new Stack<TreeNode> ();
            stack.Push (null);

            while (node != null) {
                seen.Add (node);

                if (IsLeaf (node)) {
                    node = stack.Pop ();
                } else {
                    var children = GetChildren (node);
                    var unseenChild = children.FirstOrDefault (child => !seen.Contains (child));

                    if (unseenChild != null) {
                        stack.Push (node);
                        node = unseenChild;
                    } else {
                        node = stack.Pop ();
                    }
                }
            }

            return seen.Distinct ();
        }

        static IEnumerable<TreeNode> GetChildren (TreeNode node)
        {
            return node
                .Transitions
                .Where (t => t.Value.Target != null)
                .Select (t => t.Value.Target)
                .Distinct ();
        }

        static bool IsLeaf (TreeNode node)
        {
            return node.IsTerminal;
        }
    }
}

