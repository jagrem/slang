using System.Collections.Generic;
using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class Range : Rule
    {
        public Range (char lowerInclusive, char upperInclusive)
        {
            var characters = new List<char> ();

            for (var c = lowerInclusive; c <= upperInclusive; c++)
            {
                characters.Add (c);   
            }

            Characters = characters.ToArray ();
        }

        public IEnumerable<char> Characters { get; private set; }
    }
}

