using Irony.Interpreter.Ast;

namespace slang.AST
{
    public class TraitDeclarationNode : AstNode
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
    }
}
