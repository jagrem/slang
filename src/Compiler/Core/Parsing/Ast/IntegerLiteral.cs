namespace slang.Compiler.Core.Parsing.Ast
{
    public class IntegerLiteral : Literal
    {
        public IntegerLiteral(string value) : base(value, "System.Int32")
        {
        }
    }
}
