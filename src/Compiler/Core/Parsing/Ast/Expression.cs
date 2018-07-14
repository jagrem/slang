namespace slang.Compiler.Core.Parsing.Ast
{
    public class Expression
    {
        public string Type { get; }
        
        public Expression (Literal literal)
        {
            Type = literal.Type;
        }
    }
}
