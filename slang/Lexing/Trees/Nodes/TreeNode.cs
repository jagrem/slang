namespace slang.Lexing.Trees.Nodes
{
    public class TreeNode
    {
        public int Index { get; private set; }
        public string Name { get; private set; }
        public bool IsTerminal { get; set; }
        public Transitions Transitions { get; set; }

        public TreeNode (int index)
        {
            Index = index;
            Name = "s" + index;
            Transitions = new Transitions ();
        }
    }
}
