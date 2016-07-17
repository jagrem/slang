namespace slang.Lexing.Rules.Core
{
    public class BinaryRule : Rule
    {
        public BinaryRule (Rule left, Rule right)
        {
            Left = left;
            Right = right;
        }

        public Rule Left { get; }
        public Rule Right { get; }
    }
}
