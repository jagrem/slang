using slang.Lexing.Trees.Nodes;
using System.Collections.Generic;

namespace slang.Lexing.Trees
{
    public class Tree
    {
        public Tree() : this(new TreeNode())
        {
        }

        public Tree(TreeNode root)
        {
            Root = root;
        }

        public TreeNode Root { get; }

        public IEnumerable<TreeNode> Leaves { get { return TreeBuilder.GetLeafNodes (Root); } }
    }
}
