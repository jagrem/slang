namespace slang.Lexing.Rules
{
    class OrRule : Rule
    {
        public Rule Left { get; set; }
        public Rule Right { get; set; }

        public OrRule (Rule left, Rule right)
        {
            Right = right;
            Left = left;
        }
    }
}

