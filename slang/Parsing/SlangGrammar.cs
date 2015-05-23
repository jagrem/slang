using Irony.Parsing;
using Irony.Interpreter.Ast;
using slang.AST;

namespace slang.Parsing
{
    [Language("scarf","0.0.0.0","Scala-like .NET language")]
    public class SlangGrammar : Grammar
    {
        public SlangGrammar ()
        {
            //LanguageFlags = LanguageFlags.CreateAst;

            var program = new NonTerminal ("program", typeof(ProgramNode));
            var package = new NonTerminal ("package", typeof(PackageNode));
            var packageName = new IdentifierTerminal ("packageName");

            var declarations = new NonTerminal ("declarations", typeof(AstNode));

            var declaration = new NonTerminal ("declaration", typeof(AstNode));
            var classDeclaration = new NonTerminal ("classDeclaration", typeof(AstNode));
            var interfaceDeclaration = new NonTerminal ("interfaceDeclaration", typeof(AstNode));
            var traitDeclaration = new NonTerminal ("traitDeclaration", typeof(AstNode));
            var objectDeclaration = new NonTerminal ("objectDeclaration", typeof(AstNode));

            var className = new IdentifierTerminal ("className");
            var interfaceName = new IdentifierTerminal ("interfaceName");
            var traitName = new IdentifierTerminal ("traitName");
            var objectName = new IdentifierTerminal ("objectName");

            var mixins = new NonTerminal ("mixins", typeof(AstNode));
            var mixin = new NonTerminal ("mixin", typeof(AstNode));

            var members = new NonTerminal ("members", typeof(AstNode));
            var member = new NonTerminal ("member", typeof(AstNode));
            var memberName = new IdentifierTerminal ("memberName");

            var property = new NonTerminal ("property", typeof(AstNode));
            var propertyBody = new NonTerminal ("propertyBody", typeof(AstNode));
            var getter = new NonTerminal ("getter", typeof(AstNode));
            var setter = new NonTerminal ("setter", typeof(AstNode));

            var function = new NonTerminal ("function", typeof(FunctionNode));
            var functionBody = new NonTerminal ("functionBody", typeof(AstNode));

            var parameters = new NonTerminal ("parameters", typeof(AstNode));
            var parameter = new NonTerminal ("parameter", typeof(AstNode));
            var parameterName = new IdentifierTerminal ("parameterName");

            var returns = new NonTerminal ("returns", typeof(AstNode));

            var expressions = new NonTerminal ("expressions", typeof(AstNode));
            var expression = new NonTerminal ("expression", typeof(AstNode));
            var number = new NumberLiteral ("number");
            var variable = new IdentifierTerminal ("variable");
            var text = new QuotedValueLiteral ("text","\"",System.TypeCode.String);

            var binaryOperator = new NonTerminal ("binaryOperator", typeof(AstNode));
            var unaryOperator = new NonTerminal ("unaryOperator", typeof(AstNode));

            var invocation = new NonTerminal ("invocation", typeof(AstNode));
            var arguments = new NonTerminal ("arguments");

            var lambda = new NonTerminal ("lambda");

            var types = new NonTerminal ("types");
            var type = new NonTerminal ("type");
            var typeName = new IdentifierTerminal ("typeName");

            var lambdaType = new NonTerminal ("lambdaType");
            var genericType = new NonTerminal ("genericType");

            Root = program;

            program.Rule = MakeStarRule (program, null, package);
            package.Rule = ToTerm("package") + packageName + "{" + declarations + "}";
            declarations.Rule = MakeStarRule (declarations, null, declaration);
            declaration.Rule = classDeclaration | interfaceDeclaration | traitDeclaration | objectDeclaration;
            classDeclaration.Rule = ToTerm("class") + className + mixins + "{" + members +  "}";
            interfaceDeclaration.Rule = ToTerm ("interface") + interfaceName + mixins + "{" + "}";
            traitDeclaration.Rule = ToTerm("trait") + traitName + mixins + "{" + members + "}";
            objectDeclaration.Rule = ToTerm ("object") + objectName + mixins + "{" + members + "}";
            mixins.Rule = (ToTerm(":") + MakeStarRule (mixins, ToTerm (","), mixin)) | Empty;
            mixin.Rule = className | interfaceName | traitName;
            members.Rule = MakeStarRule (members, null, member);
            member.Rule = property | function;
            property.Rule = ToTerm ("def") + memberName + returns + ToTerm("=") + propertyBody;
            propertyBody.Rule = (ToTerm("{") + getter + setter + "}") | ToTerm ("???");
            getter.Rule = (ToTerm ("get") + "=" + functionBody) | Empty;
            setter.Rule = (ToTerm ("set") + "=" + functionBody) | Empty;
            function.Rule = ToTerm ("def") + memberName + "(" + parameters + ")" + returns + ToTerm ("=") + functionBody;
            returns.Rule = (ToTerm (":") + type) | Empty;
            parameters.Rule = MakeStarRule (parameters, ToTerm(","), parameter);
            parameter.Rule = parameterName + ":" + type;
            functionBody.Rule =  ToTerm ("???") | (ToTerm ("{" + "}")) | expression | (ToTerm("{") + expressions + "}");
            expressions.Rule = MakePlusRule (expressions, null, expression);
            expression.Rule = number | variable | text | (expression + binaryOperator + expression) | invocation | lambda ;
            invocation.Rule = variable + ToTerm("(") + arguments + ")";
            arguments.Rule = MakeStarRule (arguments, ToTerm(","), expression);
            lambda.Rule = (variable | (ToTerm ("(") + parameters + ")")) + ToTerm ("=>") + functionBody;
            types.Rule = MakePlusRule (types, ToTerm(","), typeName);
            type.Rule = typeName | lambdaType | genericType;
            lambdaType.Rule = (types| ("("  + ")")) + ToTerm ("=>") + type;
            genericType.Rule = typeName + "[" + types + "]";
            binaryOperator.Rule = 
                ToTerm ("+")            // Addition
                | ToTerm ("=")          // Assignment
                | ToTerm ("+=")         // Addition and assignment
                | ToTerm ("-")          // Subtraction
                | ToTerm ("-=")         // Subtraction and assignment
                | ToTerm ("/")          // Division
                | ToTerm ("/=")         // Division and assignment
                | ToTerm ("*")          // Multiplication
                | ToTerm ("*=")         // Multiplication and assignment
                | ToTerm ("%")          // Modulus
                | ToTerm ("%=")         // Modulus and assignment
                | ToTerm ("^")          // Binary NOT
                | ToTerm ("&")          // Binary AND
                | ToTerm ("&=")         // Binary AND and assignment
                | ToTerm ("|")          // Binary OR
                | ToTerm ("|=")         // Binary OR and assignment
                | ToTerm ("&&")         // Logical AND
                | ToTerm ("||")         // Logical OR
                | ToTerm ("==")         // Equal to
                | ToTerm ("!=")         // Not equal to 
                | ToTerm ("<")          // Less than
                | ToTerm (">")          // Greater than
                | ToTerm ("<=")         // Less than or equal to
                | ToTerm (">=")         // Greater than or equal to
                | ToTerm ("~")          // Binary XOR
                | ToTerm ("~=")         // Binary XOR and assignment
                | ToTerm("as")          // Cast
                | ToTerm("is")          // Test type 
                | ToTerm ("=~");        // Matches
            unaryOperator.Rule = 
                ToTerm ("typeof")       // Type of
                | ToTerm ("nameof")     // Name of type
                | ToTerm("-")           // Negation
                | ToTerm("!");          // Logical NOT
        }
    }
}

