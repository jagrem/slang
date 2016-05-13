using System.Collections.Generic;
using System.Linq;

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

        public override IEnumerable<LexicalNode> GetNodeList ()
        {
            var left = Left.GetNodeList ();
            var right = Right.GetNodeList ();
            return left.Select (n => new LexicalNode (right.ToList ()));
        }
    }
}

