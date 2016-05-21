namespace slang.Lexing.Rules
{
    public class LexicalTransition
    {
        public LexicalNode Target { get; set; }
        public char Input { get; set; }

        public LexicalTransition (char input, LexicalNode target)
        {
            Input = input;
            Target = target;
        }
    }
}

