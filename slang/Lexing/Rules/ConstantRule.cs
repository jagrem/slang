using System.Collections.Generic;

namespace slang.Lexing.Rules
{
    public class ConstantRule : Rule
    {
        public char Value { get; set; }

        public ConstantRule (char value)
        {
            Value = value;
        }

        public override IEnumerable<LexicalNode> GetNodeList ()
        {
            return new [] { new LexicalNode () };
        }
    }

}

