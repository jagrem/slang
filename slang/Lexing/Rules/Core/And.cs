namespace slang.Lexing.Rules.Core
{
    public class And : Rule
    {
        public Rule Left { get; set; }
        public Rule Right { get; set; }

        public And (Rule left, Rule right)
        {
            Right = right;
            Left = left;
        }
    }
}

