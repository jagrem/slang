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
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly (new AssemblyName(definition.Name), AssemblyBuilderAccess.Run);

            //var moduleBuilder = assemblyBuilder.DefineDynamicModule (definition.Name, definition.Filename);

            //foreach (var module in definition.Modules)
            //{
            //    var attributes = TypeAttributes.Class | TypeAttributes.AnsiClass | TypeAttributes.AutoLayout | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.Public;
            //    var typeBuilder = moduleBuilder.DefineType(module.Namespace + "." + module.Name, attributes);
            //    typeBuilder.CreateType();

            //    foreach (var function in module.FunctionDefinitions)

            //    {
            //        var functionVisibility = function.AccessModifier == AccessModifierType.Public ? MethodAttributes.Public : MethodAttributes.Private;
            //        var functionBuilder = typeBuilder.DefineMethod(function.Name, functionVisibility | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(int), new Type[0]);
            //        var generator = functionBuilder.GetILGenerator();
            //        generator.Emit(OpCodes.Ldc_I4_1);
            //        generator.Emit(OpCodes.Ret);
            //    }
            //}

            // NOTE: Dynamic assemblies cannot be saved to disk in .NET Core yet
            //assemblyBuilder.Save (definition.Filename);
        }
    }
}

