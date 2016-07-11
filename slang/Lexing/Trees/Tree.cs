using slang.Lexing.Trees.Nodes;
using System.Collections.Generic;

namespace slang.Lexing.Trees
{
    public class Tree
    {
        public Tree() : this(new Node())
        {
        }

        public Tree(Node root)
        {
            Root = root;
        }

        public Node Root { get; }

        public IEnumerable<Node> Leaves { get { return TreeBuilder.GetLeafNodes (Root); } }
    }
}
