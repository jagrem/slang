using System.Reflection;
using System;
using System.Reflection.Emit;
using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Compiler.Clr.Compilation.IL
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
                    var typeBuilder = moduleBuilder.DefineType (
                        classDefinition.Namespace + "." + classDefinition.Name,
                        TypeAttributes.Class | TypeAttributes.AnsiClass | TypeAttributes.AutoLayout | TypeAttributes.Abstract | TypeAttributes.Sealed | visibility);

                    foreach(var function in classDefinition.FunctionDefinitions) {
                        var functionVisibility = function.AccessModifier == AccessModifierType.Public ? MethodAttributes.Public : MethodAttributes.Private;
                        var methodBuilder = typeBuilder.DefineMethod (function.Name, functionVisibility | MethodAttributes.Static | MethodAttributes.HideBySig);
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

