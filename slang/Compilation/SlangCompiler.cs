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
                .Aggregate (AssemblyDefinitionBuilder.Create (compilationUnit.Name), (builder, module) => builder.AddModule (module))
                .Build ();
            
            Generator.GenerateAssembly (assemblyDefinition);
        }

        public static void Compile(CompilationRoot compilationRoot)
        {
            compilationRoot.CompilationUnits.ToList ().ForEach (Compile);
        }
    }
}
