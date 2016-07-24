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
            return string.Join (
                Environment.NewLine + Environment.NewLine,
                GetAllNodes (node)
                .OrderBy (n => n.Index)
                .Select (n => string.Format (
                    "Node {0}{1}{2} [{3}]",
                    n.Name,
                    n.IsTerminal ? "(terminal)" : string.Empty,
                    n.Transitions.Any (t => t.Value.TokenProducer != null) ? " => Token " : string.Empty,
                    string.Join(Environment.NewLine, GetNodeDescriptions (n))
                )));
        }
                         
        static IEnumerable<string> GetNodeDescriptions(TreeNode node)
        {
            return string
                .Join (",", GetTransitionDescriptions (node))
                .Select ((x, i) => new { Index = i, Value = x })
                .GroupBy (x => x.Index / 160)
                .Select (x => new string (x.Select (v => v.Value).ToArray ()));
        }

        static IEnumerable<string> GetTransitionDescriptions(TreeNode node)
        {
            return node
                .Transitions
                .Select (t => {
                    var key = t.Key != Character.Any ? t.Key.Value.ToString () : "Any";
                    var value = t.Value != null && t.Value.Target != null ? t.Value.Target.Name : "Undefined";
                    return string.Format ("[{0} => {1}]", key, value);
            });
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

