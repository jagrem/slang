using System.Collections.Generic;
using System.Linq;
using System;
using slang.Lexing.Transitions;

namespace slang.Lexing.Tools
{
    static class CodeGeneration
    {
        public static IEnumerable<string> GetStatesForKeywords()
        {
            return GetTransitionsForKeywords ()
                .Where(t => t.ToState != "Zero")
                .Select(t => t.ToState);
        }

        public static IEnumerable<Transition> GetTransitionsForKeywords()
        {
            return GetTransitionsForTerms ("Zero", slang.Lexing.Tokens.Constants.Keywords.AllKeywords.Select (t => t.Value));
        }

        public static IEnumerable<Transition> GetTransitionsForTerms(string fromState, IEnumerable<string> terms, int startingFrom = 0)
        {
            var transitions = new List<Transition> ();
            var groups = terms.GroupBy(k => new String(k.Take(startingFrom + 1).ToArray ()));

            foreach (var group in groups) {

                string stateName = GetStateName (group);
                var characterThatTriggersTransition = group.Key.Last ();
                transitions.Add (new Transition { FromState = fromState, ToState = stateName, Character = characterThatTriggersTransition });

                var charactersReceivedSoFar = group.Key;
                transitions.AddRange (group.Where (keyword => keyword == charactersReceivedSoFar).SelectMany (keyword => GetTerminalTransitions (stateName, keyword)));

                transitions.AddRange (GetTransitionsForTerms (stateName, group.Where(k => k != charactersReceivedSoFar).ToList (), startingFrom + 1));
            }

            return transitions;
        }

        static string GetStateName (IGrouping<string, string> group)
        {
            string statePrefix = group.Count () > 1 ? "M" : "K";
            var charactersReceivedSoFar = group.Key;
            var keywordName = group.Count () > 1 ? string.Join ("_or_", group) : group.First ();
            var isFinalState = charactersReceivedSoFar == keywordName;
            return isFinalState ? statePrefix + "_" + keywordName : statePrefix + "_" + charactersReceivedSoFar + "_" + keywordName;
        }

        static TerminalTransition[] GetTerminalTransitions (string stateName, string keyword)
        {
            return new[] {
                new TerminalTransition { Token = keyword, FromState = stateName, ToState = "Zero", Character = ' ' },
                new TerminalTransition { Token = keyword, FromState = stateName, ToState = "Zero", Character = (char)0 }
            };
        }

        public static IEnumerable<Transition> GetTransitionsForPunctuation() {
            return slang.Lexing.Tokens.Constants.Punctuation.GetAllPunctuation ()
                .SelectMany (t => new[] {
                    new Transition { FromState = "Zero", ToState = "P_" + t.Name, Character = t.Value[0] },
                    new TerminalTransition { FromState = "P_" + t.Name, ToState = "Zero", Character = t.Value[0], Token = "Symbol"  },
                });
        }

        public static string GetCharacterAsQuotedCharacter(char c)
        {
            string value;

            switch(c) {
            case (char)0: return "(char)0";
            case '\'':
                value = "\\\'";
                break;
            case '\\':
                value = "\\\\";
                break;
            default:
                value = c.ToString ();
                break;
            }

            return "'" + value + "'";
        }
    }
}

