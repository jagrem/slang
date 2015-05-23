using Irony.Interpreter.Ast;

namespace slang.AST
{

    public class ClassDeclarationNode : AstNode
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
    }
    
}
