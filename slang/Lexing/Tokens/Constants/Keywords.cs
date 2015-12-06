using System.Collections.Generic;
using slang.Lexing.Tokens;

namespace slang.Lexing.Tokens.Constants
{
    public static class Keywords
    {
        public static IEnumerable<TokenInfo> AllKeywords { 
            get { 
                return new[] {
                    new TokenInfo("abstract", "abstract"),
                    new TokenInfo("as", "as"),
                    new TokenInfo("async", "async"),
                    new TokenInfo("await", "await"),
                    new TokenInfo("base", "base"),
                    new TokenInfo("bool", "bool"),
                    new TokenInfo("break", "break"),
                    new TokenInfo("byte", "byte"),
                    new TokenInfo("case", "case"),
                    new TokenInfo("catch", "catch"),
                    new TokenInfo("char", "char"),
                    new TokenInfo("checked", "checked"),
                    new TokenInfo("class", "class"),
                    new TokenInfo("continue", "continue"),
                    new TokenInfo("decimal", "decimal"),
                    new TokenInfo("def", "def"),
                    new TokenInfo("default", "default"),
                    new TokenInfo("dynamic", "dynamic"),
                    new TokenInfo("do", "do"),
                    new TokenInfo("double", "double"),
                    new TokenInfo("else", "else"),
                    new TokenInfo("enum", "enum"),
                    new TokenInfo("extends", "extends"),
                    new TokenInfo("false", "false"),
                    new TokenInfo("finally", "finally"),
                    new TokenInfo("fixed", "fixed"),
                    new TokenInfo("float", "float"),
                    new TokenInfo("for", "for"),
                    new TokenInfo("if", "if"),
                    new TokenInfo("implicit", "implicit"),
                    new TokenInfo("import", "import"),
                    new TokenInfo("in", "in"),
                    new TokenInfo("int", "int"),
                    new TokenInfo("internal", "internal"),
                    new TokenInfo("is", "is"),
                    new TokenInfo("lock", "lock"),
                    new TokenInfo("long", "long"),
                    new TokenInfo("match", "match"),
                    new TokenInfo("new", "new"),
                    new TokenInfo("object", "object"),
                    new TokenInfo("operator", "operator"),
                    new TokenInfo("override", "override"),
                    new TokenInfo("package", "package"),
                    new TokenInfo("private", "private"),
                    new TokenInfo("protected", "protected"),
                    new TokenInfo("readonly", "readonly"),
                    new TokenInfo("return", "return"),
                    new TokenInfo("sealed", "sealed"),
                    new TokenInfo("this", "this"),
                    new TokenInfo("throw", "throw"),
                    new TokenInfo("trait", "trait"),
                    new TokenInfo("true", "true"),
                    new TokenInfo("try", "try"),
                    new TokenInfo("type", "type"),
                    new TokenInfo("val", "val"),
                    new TokenInfo("var", "var"),
                    new TokenInfo("while", "while"),
                    new TokenInfo("with", "with"),
                    new TokenInfo("yield", "yield")
                };
            }
        }
    }
}

