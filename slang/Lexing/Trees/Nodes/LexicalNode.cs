namespace slang.Lexing.Trees.Nodes
{
    public class LexicalNode
    {
        public LexicalTransitions Transitions { get; set; }

        public LexicalNode ()
        {
            Transitions = new LexicalTransitions ();
        }
    }
}

