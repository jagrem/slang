using System.IO;
using slang.Compiler.Coco.Parsing;
using System;
using slang.Compiler.Core.Parsing.Ast;

namespace slang.Parsing
{
    public static class SlangParser
    {
        public static Module Parse (Stream stream)
        {
            var parser = new Parser (new Scanner (stream));
            parser.Parse ();
            return parser.Module;
        }

        public static Module Parse (string fileName)
        {
            if (!File.Exists (fileName)) {
                throw new ArgumentException ($"{fileName} does not exist");
            }

            using (var stream = File.OpenRead (fileName)) {
                return Parse (stream);
            }
        }
    }
}
