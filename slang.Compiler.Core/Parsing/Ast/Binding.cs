namespace slang.Compiler.Core.Parsing.Ast
{
    public class Binding
    {
        public BindingDeclaration Declaration { get; private set; }

        public Expression Body { get; private set; }

        public Binding (BindingDeclaration declaration, Expression body)
        {
            Declaration = declaration;
            Body = body;
        }
    }
}

