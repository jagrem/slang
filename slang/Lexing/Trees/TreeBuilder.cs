using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;
using System;
using slang.Lexing.Rules.Extensions;

namespace slang.Lexing.Trees
{
    public static class TreeBuilder
    {
        static int index = 0;

        public static Tree Build (Rule rule)
        {
            var ruleStack = new Stack<Rule> ();
            var seen = new List<TreeContainerNode> ();
            var start = (Rule)null;
            ruleStack.Push (start);

            var treeStack = new Stack<TreeContainerNode> ();
            var tree = new TreeContainerNode ();
            treeStack.Push (tree);

            while (rule != start) {
                if (rule is BinaryRule) {
                    if (tree.Children.Count () > 1 &&  seen.Contains (tree.Children[1])) {
                        if (rule is Or)
                            tree.Tree = Evaluate ((Or)rule, tree.Children [0].Tree, tree.Children [1].Tree);
                        else
                            tree.Tree = Evaluate ((And)rule, tree.Children [0].Tree, tree.Children [1].Tree);

                        tree = treeStack.Pop ();
                        rule = ruleStack.Pop ();
                    } else if (seen.Contains (tree)) {
                        ruleStack.Push (rule);
                        rule = ((BinaryRule)rule).Right;

                        var right = new TreeContainerNode ();
                        tree.Children.Add (right);
                        treeStack.Push (tree);
                        tree = right;
                    } else {
                        seen.Add (tree);
                        ruleStack.Push (rule);
                        rule = ((BinaryRule)rule).Left;

                        var left = new TreeContainerNode ();
                        tree.Children.Add (left);
                        treeStack.Push (tree);
                        tree = left;
                    }
                }

                if (rule is Repeat) {
                    if (seen.Contains (tree)) {
                        tree.Tree = Evaluate ((Repeat)rule, tree.Children [0].Tree);
                        tree = treeStack.Pop ();

                        rule = ruleStack.Pop ();
                    } else {
                        seen.Add (tree);
                        ruleStack.Push (rule);
                        rule = ((Repeat)rule).Value;

                        var value = new TreeContainerNode ();
                        tree.Children.Add (value);
                        treeStack.Push (tree);
                        tree = value;
                    }
                }

                if(rule is Range)
                {
                    seen.Add (tree);
                    tree.Tree = Evaluate ((Range)rule);
                    tree = treeStack.Pop ();
                    rule = ruleStack.Pop ();
                }

                if (rule is Constant) {
                    seen.Add (tree);
                    tree.Tree = Evaluate ((Constant)rule);
                    tree = treeStack.Pop ();
                    rule = ruleStack.Pop ();
                }
            }

            return tree.Tree;
        }

        static Tree Evaluate (Or rule, Tree left, Tree right)
        {
            var tree = left.Merge (right);

            if (rule.TokenCreator != null) {
                MapLeaves (tree, leaf => leaf.Transitions [Character.Any] = new Transition (null, rule.TokenCreator));
            }

            MapLeaves (tree, leaf => leaf.IsTerminal = true);

            return tree;
        }

        static Tree Evaluate (And rule, Tree left, Tree right)
        {
            var tree = left.AttachChild (right);

            if (rule.TokenCreator != null) {
                MapLeaves(tree, leaf => leaf.Transitions [Character.Any] = new Transition (null, rule.TokenCreator));
            }

            MapLeaves(tree, leaf => leaf.IsTerminal = true);

            return tree;
        }

        static Tree Evaluate (Repeat rule, Tree value)
        {
            var tree = value;
            var transitions = tree.Root.Transitions;

            tree.Leaves
                .ToList ()
                .ForEach (leaf => {
                    leaf.IsTerminal = true;
                    transitions.ToList ().ForEach (transition => leaf.Transitions [transition.Key] = transition.Value);
                    if (rule.TokenCreator != null) {
                        leaf.Transitions [Character.Any] = new Transition (null, rule.TokenCreator);
                    }
                });

            return tree;
        }

        static void MapLeaves(Tree tree, Action<TreeNode> action) {
            tree.Leaves.ToList ().ForEach (action);
        }

        static Tree Evaluate(Range rule)
        {
            var root = new TreeNode (index++);

            rule.Characters.ToList ().ForEach(c => {
                var key = Character.FromChar (c);
                var value = new TreeNode (index++) { IsTerminal = true };

                if (rule.TokenCreator != null) {
                    value.Transitions.Add (Character.Any, new Transition (null, rule.TokenCreator));
                }

                root.Transitions.Add (key, new Transition (value));
            });

            return new Tree (root);
        }

        static Tree Evaluate(Constant rule)
        {
            var root = new TreeNode (index++);
            var key = Character.FromChar (rule.Value);
            var value = new TreeNode(index++) { IsTerminal = true };

            if (rule.TokenCreator != null) {
                value.Transitions.Add (Character.Any, new Transition (null, rule.TokenCreator));
            }

            root.Transitions.Add (key, new Transition (value));
            return new Tree (root);
        }

        public static IEnumerable<TreeNode> GetLeafNodes (TreeNode node)
        {
            var leaves = new List<TreeNode> ();
            var seen = new List<TreeNode> ();
            var stack = new Stack<TreeNode> ();
            stack.Push (null);

            while (node != null) 
            {
                seen.Add (node);

                if (IsLeaf (node)) {
                    leaves.Add (node);
                    node = stack.Pop ();
                } else {
                    var children = GetChildren (node);
                    var unseenChild = children.FirstOrDefault (child => !seen.Contains (child));

                    if(unseenChild != null) {
                        stack.Push (node);
                        node = unseenChild;
                    } else {
                        node = stack.Pop ();
                    }
                }
            }

            return leaves;
        }

        static IEnumerable<TreeNode> GetChildren(TreeNode node)
        {
            return node
                .Transitions
                .Where (t => t.Value.Target != null)
                .Select (t => t.Value.Target)
                .Distinct ();
        }

        static bool IsLeaf(TreeNode node) {
            return node.IsTerminal;
        }
    }
}

