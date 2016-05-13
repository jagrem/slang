using System.Collections.Generic;
using System.Linq;

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

        public override IEnumerable<LexicalNode> GetNodeList ()
        {
            var left = Left.GetNodeList ();
            var right = Right.GetNodeList ();
            return left.Concat (right);
        }
    }
}

