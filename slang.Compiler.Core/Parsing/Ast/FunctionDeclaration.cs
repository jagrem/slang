using System.Collections.Generic;

namespace slang.Compiler.Core.Parsing.Ast
{
    public class FunctionDeclaration : BindingDeclaration
    {
        public IEnumerable<TypeDeclaration> Parameters { get; private set; }
        public TypeDeclaration Returns { get; private set; }
        public FunctionDeclaration (string functionName, List<TypeDeclaration> parameters, TypeDeclaration returns)
        {
            Name = functionName;
            Parameters = parameters;
            Returns = returns;
        }
    }
}
