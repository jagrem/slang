using slang.Compiler.Core.Compilation;
using System.Linq;
using slang.Compiler.Clr.Compilation.Definitions.Builders;
using slang.Compiler.Clr.Compilation.IL;
using slang.Translation;
using slang.Parsing;

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
                .Aggregate (GetAssemblyDefinitionBuilder (compilationUnit), (builder, module) => builder.AddModule (module))
                .Build ();

            Generator.GenerateAssembly (assemblyDefinition);
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
