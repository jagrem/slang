using System.IO;
using slang.Compiler.Coco.Parsing;
using slang.Translation;
using slang.Compiler.Clr.Compilation.IL;

namespace slang.Compilation
{
    public static class SlangCompiler
    {
        public static void Compile(Stream stream)
        {
            var parser = new Parser (new Scanner (stream));
            parser.Parse ();
            var assemblyDefinition = AstTranslator.TranslateToAssemblyDefinition (new [] { parser.Module });
            Generator.GenerateAssembly (assemblyDefinition);
        }
    }
}
