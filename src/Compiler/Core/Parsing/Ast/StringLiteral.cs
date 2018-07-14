namespace slang.Compiler.Core.Parsing.Ast
{
    public class StringLiteral : Literal
    {
        public StringLiteral(string value) : base(value, "System.String")
        {
        }
    }
}
