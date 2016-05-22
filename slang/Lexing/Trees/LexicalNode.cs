namespace slang.Lexing.Rules
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

