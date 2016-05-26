namespace slang.Lexing.Trees.Nodes
{
    public class Node
    {
        public Transitions Transitions { get; set; }

        public Node ()
        {
            Transitions = new Transitions ();
        }
    }
}

