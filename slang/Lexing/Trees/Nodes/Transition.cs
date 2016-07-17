using System;
using slang.Lexing.Tokens;
namespace slang.Lexing.Trees.Nodes
{
    public class Transition
    {
        public Transition (TreeNode target, Func<string,Token> tokenProducer = null)
        {
            Target = target;
            TokenProducer = tokenProducer;
        }

        public Token GetToken(string context)
        {
            if(TokenProducer != null)
            {
                return TokenProducer (context);
            }

            return null;
        }

        public Func<string,Token> TokenProducer { get; private set; }

        public void Returns (Func<string,Token> tokenProducer)
        {
            TokenProducer = tokenProducer;
        }

        public TreeNode Target { get; }
    }
}

