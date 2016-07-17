namespace slang.Lexing.Trees.Nodes
{
    public class TreeNode
    {
        public bool IsTerminal { get; set; }
        public Transitions Transitions { get; set; }

        public TreeNode ()
        {
            Transitions = new Transitions ();
        }
    }
}
