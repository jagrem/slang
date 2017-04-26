using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compiler.Clr.Compilation.Core.Builders
{
    public class ModuleDefinitionBuilder
    {
        string _name;
        string _namespace;
        readonly IList<TypeDefinitionBuilder> _typeBuilders = new List<TypeDefinitionBuilder>();
        readonly IList<FunctionDefinitionBuilder> _functionBuilders = new List<FunctionDefinitionBuilder>();

        ModuleDefinitionBuilder()
        {
        }

        public static ModuleDefinitionBuilder Create()
        {
            return new ModuleDefinitionBuilder();
        }

        public ModuleDefinitionBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ModuleDefinitionBuilder WithNamespace(string @namespace)
        {
            _namespace = @namespace;
            return this;
        }

        public ModuleDefinitionBuilder AddType(TypeDefinitionBuilder typeBuilder)
        {
            _typeBuilders.Add(typeBuilder);
            return this;
        }

        public ModuleDefinitionBuilder AddFunction(Func<FunctionDefinitionBuilder,FunctionDefinitionBuilder> functionBuilderConfigurator)
        {
            _functionBuilders.Add(functionBuilderConfigurator(new FunctionDefinitionBuilder()));
            return this;
        }

        public ModuleDefinition Build()
        {
            return new ModuleDefinition(
                _name,
                _namespace,
                _typeBuilders.Select(typeBuilder => typeBuilder.Build()),
                _functionBuilders.Select(functionBuilder => functionBuilder.Build()));
        }
    }
}
