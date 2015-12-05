using slang.Lexing.Tokens;
using System.Collections.Generic;

namespace slang.Lexing.Tokens.Keywords
{
    public class Keyword : Token
    {
        public Keyword (string value) 
        {
            Value = value;
        }

        public static IEnumerable<string> AllKeywords { 
            get { 
                return new [] {
                    "abstract",
                    "as",
                    "async",
                    "await",
                    "base",
                    "bool",
                    "break",
                    "byte",
                    "case",
                    "catch",
                    "char",
                    "checked",
                    "class",
                    "continue",
                    "decimal",
                    "def",
                    "default",
                    "dynamic",
                    "do",
                    "double",
                    "else",
                    "enum",
                    "extends",
                    "false",
                    "finally",
                    "fixed",
                    "float",
                    "for",
                    "if",
                    "implicit",
                    "import",
                    "in",
                    "int",
                    "internal",
                    "is",
                    "lock",
                    "long",
                    "match",
                    "new",
                    "object",
                    "operator",
                    "override",
                    "package",
                    "private",
                    "protected",
                    "readonly",
                    "return",
                    "sealed",
                    "this",
                    "throw",
                    "trait",
                    "true",
                    "try",
                    "type",
                    "val",
                    "var",
                    "while",
                    "with",
                    "yield"
                };
            }
        }
    }

}

