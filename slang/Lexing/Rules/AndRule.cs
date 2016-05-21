namespace slang.Lexing.Rules
{
    public class AndRule : Rule
    {
        public Rule Left { get; set; }
        public Rule Right { get; set; }

        public AndRule (Rule left, Rule right)
        {
            Right = right;
            Left = left;
        }
    }
}

