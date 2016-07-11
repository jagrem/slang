using System.Linq;
namespace slang.Lexing.Trees
{
    public static class TreeExtensions
    {
        public static Tree AttachChild(this Tree parent, Tree child)
        {
            var parentLeaves = parent.Leaves.ToList ();
            var childTransitions = child.Root.Transitions.ToList ();

            parentLeaves.ForEach (parentLeaf =>
                                  childTransitions.ForEach (childTransition =>
                                          parentLeaf
                                              .Transitions
                                              .Add (childTransition.Key, childTransition.Value)));
            return parent;
        }

        public static Tree Merge (this Tree left, Tree right)
        {
            var tree = new Tree ();
            var leftTransitions = left.Root.Transitions.ToList() ;
            var rightTransitions = right.Root.Transitions.ToList();
            var transitions = leftTransitions.Concat (rightTransitions);
            transitions.ToList ().ForEach (t => tree.Root.Transitions.Add (t.Key, t.Value));
            return tree;
        }
    }
}

