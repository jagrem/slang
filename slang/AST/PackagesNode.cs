using Irony.Interpreter.Ast;
using System.Collections.Generic;

namespace slang.AST
{
    public class ProgramNode : AstNode
    {
        public IEnumerable<PackageNode> Packages { get; set; }
    }
    
}
