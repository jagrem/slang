using System.Collections.Generic;

namespace slang.Lexing.Trees.Nodes
{
    public class TreeContainerNode
    {
        public TreeContainerNode() 
        {
            Children = new List<TreeContainerNode> ();
        }
        public Tree Tree { get; set; }
        public IList<TreeContainerNode> Children { get; set; }
    }
}
