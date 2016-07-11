using System;
using slang.Lexing.Tokens;
namespace slang.Lexing.Trees.Nodes
{
    public class Transition
    {
        public Transition (Node target, Func<Token> tokenProducer = null)
        {
            Target = target;
            TokenProducer = tokenProducer;
        }

        public Token GetToken()
        {
            if(TokenProducer != null)
            {
                return TokenProducer ();
            }

            return null;
        }

        public Func<Token> TokenProducer { get; private set; }

        public void Returns (Func<Token> tokenProducer)
        {
            TokenProducer = tokenProducer;
        }

        public Node Target { get; }
    }
}

