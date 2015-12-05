using System.Collections.Generic;
using System.Linq;
using System;
using slang.Lexing.Transitions;

namespace slang.Lexing.Tools
{
    public static class CodeGeneration
    {
        public static IEnumerable<string> GetStatesForKeywords(IEnumerable<string> keywords, int startingFrom = 0)
        {
            return GetTransitionsForKeywords ("Zero", keywords, startingFrom).Where(t => t.ToState != "Zero").Select(t => t.ToState);
        }

        public static IEnumerable<Transition> GetTransitionsForKeywords(string fromState, IEnumerable<string> keywords, int startingFrom = 0)
        {
            var transitions = new List<Transition> ();

            var groups = keywords.GroupBy(k => new String(k.Take(startingFrom + 1).ToArray ()));

            foreach (var group in groups) {

                string statePrefix = group.Count() > 1 ? "M" : "K";
                var charactersReceivedSoFar = group.Key;
                var characterThatTriggersTransition = group.Key.Last ();
                var keywordName = group.Count () > 1 ? string.Join ("_or_", group) : group.First ();
                var isFinalState = charactersReceivedSoFar == keywordName;
                var stateName = isFinalState ? statePrefix + "_" + keywordName : statePrefix + "_" + charactersReceivedSoFar + "_" + keywordName;

                transitions.Add (
                    new Transition {
                        FromState = fromState,
                        ToState = stateName,
                        Character = characterThatTriggersTransition,
                    });

                foreach(var keyword in group) {
                    if(charactersReceivedSoFar == keyword)
                        transitions.AddRange (new [] {
                            new TerminalTransition {
                                Token = keyword,
                                FromState = stateName,
                                ToState = "Zero",
                                Character = ' '
                            },
                            new TerminalTransition {
                                Token = keyword,
                                FromState = stateName,
                                ToState = "Zero",
                                Character = (char)0
                            }
                        });
                }

                transitions.AddRange (GetTransitionsForKeywords (stateName, group.Where(k => k != charactersReceivedSoFar).ToList (), startingFrom + 1));
            }

            return transitions;
        }
    }
}

