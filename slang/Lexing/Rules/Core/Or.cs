namespace slang.Lexing.Rules.Core
{
    public class Or : Rule
    {
        public Rule Left { get; set; }
        public Rule Right { get; set; }

        public Or (Rule left, Rule right)
        {
            Right = right;
            Left = left;
        }
    }
}

