using System.Reflection;
using System;
using slang.Compilation;
using System.Reflection.Emit;

namespace slang.IL
{
    public static class Generator
    {
        public static void GenerateAssembly(AssemblyDefinition definition)
        {
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly (new AssemblyName(definition.Name), AssemblyBuilderAccess.Save);

            foreach (var module in definition.Modules) {
                var moduleBuilder = assemblyBuilder.DefineDynamicModule (module.Name, module.FileName);

                foreach (var classDefinition in module.ClassDefinitions) {
                    var visibility = classDefinition.AccessModifier == AccessModifierType.Public ? TypeAttributes.Public : TypeAttributes.NotPublic;
                    var typeBuilder = moduleBuilder.DefineType (classDefinition.Name, TypeAttributes.Class | visibility);

                    foreach(var function in classDefinition.FunctionDefinitions) {
                        var functionVisibility = function.AccessModifier == AccessModifierType.Public ? MethodAttributes.Public : MethodAttributes.Private;
                        var methodBuilder = typeBuilder.DefineMethod (function.Name, functionVisibility);
                        var functionGenerator = methodBuilder.GetILGenerator ();
                        functionGenerator.ThrowException (typeof(NotImplementedException));
                    }

                    typeBuilder.CreateType ();
                }
            }
            assemblyBuilder.Save (definition.Filename);
        }
    }
}

