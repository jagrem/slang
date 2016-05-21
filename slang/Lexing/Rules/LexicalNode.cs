using System.Collections.Generic;

namespace slang.Lexing.Rules
{
    public class LexicalNode
    {
        public IList<LexicalNode> Children { get; set; }

        public IList<LexicalTransition> Transitions { get; set; }
        public LexicalNode (IList<LexicalNode> children = null)
        {
            Children = children ?? new List<LexicalNode> ();
            Transitions = new List<LexicalTransition> ();
        }
    }
}

