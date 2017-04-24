using slang.Compiler.Core.Compilation;
using System.Linq;
using slang.Translation;
using slang.Parsing;
using slang.Compiler.Clr.Compilation.Core.Builders;
using slang.Compiler.Clr.Compilation.IL;

namespace slang.Compilation
{
    public static class SlangCompiler
    {
        public static void Compile(CompilationUnit compilationUnit)
        {
            var assemblyDefinition = compilationUnit
                .SourceFiles
                .AsParallel ()
                .Select (sourceFile => SlangParser.Parse (sourceFile))
                .ToList ()
                .Aggregate (
                    GetAssemblyDefinitionBuilder (compilationUnit),
                    (builder, module) => builder.AddModule (module))
                .Build ();

            new MsilAssemblyGenerator().GenerateDynamicAssembly (assemblyDefinition);
        }

        static AssemblyDefinitionBuilder GetAssemblyDefinitionBuilder (CompilationUnit compilationUnit)
        {
            var builder = AssemblyDefinitionBuilder.Create (compilationUnit.Metadata.Name);

            if(compilationUnit.Metadata.AssemblyType == AssemblyType.Executable) {
                builder.AsExecutable () ; 
            } else {
                builder.AsLibrary () ; 
            } 

            return builder;
        }

        public static void Compile(CompilationRoot compilationRoot)
        {
            compilationRoot.CompilationUnits.ToList ().ForEach (Compile);
        }
    }
}
