using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;
using slang.Lexing.Trees.Transformers;

namespace slang.Lexing.Trees
{
    public static class LexicalTreeBuilder
    {
        public static Node Build (Rule rule)
        {
            var start = new StartNode ();
            rule.Transform (new [] { start });
            return start;
        }
    }
}

