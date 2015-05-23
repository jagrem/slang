using Irony.Interpreter.Ast;

namespace slang.AST
{
    public class ObjectDeclarationNode : AstNode
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
    }
}
