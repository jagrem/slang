using System.Reflection;
using System.Reflection.Emit;
using slang.Compiler.Clr.Compilation.Definitions;
using System;

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
                        var functionBuilder = typeBuilder.DefineMethod (function.Name, functionVisibility | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(int), new Type[0]);
                        var generator = functionBuilder.GetILGenerator ();
                        generator.Emit (OpCodes.Ldc_I4_1);
                        generator.Emit (OpCodes.Ret);
                    }

                    typeBuilder.CreateType ();
                }
            }
            assemblyBuilder.Save (definition.Filename);
        }
    }
}

