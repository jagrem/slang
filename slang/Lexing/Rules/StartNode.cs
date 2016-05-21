using System.Collections.Generic;
namespace slang.Lexing.Rules
{
    public class StartNode : LexicalNode
    {
        public StartNode () { Children = new List<LexicalNode> (); }
    }
}
