using Irony.Parsing;
using slang.AST;

namespace slang.Parsing
{
    public class SlangParser
    {
        readonly Parser _parser;

        public SlangParser ()
        {
            _parser = new Parser (new LanguageData (new SlangGrammar ()));
        }

        public ProgramNode Parse(string input)
        {
            var parseTree = _parser.Parse (input);
            return parseTree.Root.AstNode as ProgramNode;
        }
    }
}

