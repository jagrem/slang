using NUnit.Framework;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;
using slang.Lexing.Tools;

namespace slang.Tests.Lexing
{
    [TestFixture]
    public class CodeGenerationTests
    {
        [Test]
        public void Given_keywords_starting_with_different_letters_When_getting_states_Then_a_set_of_states_is_produced_for_each_keyword()
        {
            var keywords = new[] { "ab", "bc" };
            var result = CodeGeneration.GetStatesForKeywords (keywords);
            result.ShouldBeEquivalentTo (new[] { "K_a_ab", "K_ab", "K_b_bc", "K_bc" });
        }

        [Test]
        public void Given_keywords_starting_with_the_same_letter_When_getting_states_Then_a_merged_state_is_produced()
        {
            var keywords = new[] { "abcd", "acde" };
            var result = CodeGeneration.GetStatesForKeywords (keywords).ToArray();
            result [0].Should ().Be ("M_a_abcd_or_acde");
            result [1].Should ().Be ("K_ab_abcd");
            result [2].Should ().Be ("K_abc_abcd");
            result [3].Should ().Be ("K_abcd");
            result [4].Should ().Be ("K_ac_acde");
            result [5].Should ().Be ("K_acd_acde");
            result [6].Should ().Be ("K_acde");
        }

        [Test]
        public void Given_keywords_starting_with_different_letters_When_getting_transitions_Then_separate_transitions_are_produced_for_each_keyword()
        {
            var result = CodeGeneration.GetTransitionsForKeywords ("Zero", new[] { "ab", "bc" }).ToArray ();

            result.ShouldBeEquivalentTo (
                new[] { 
                    new { Character = 'a', FromState = "Zero", ToState = "K_a_ab", Token = (string)null },
                    new { Character = 'b', FromState = "K_a_ab", ToState = "K_ab", Token = (string)null },
                    new { Character = ' ', FromState = "K_ab", ToState = "Zero", Token = "ab" },
                    new { Character = (char)0, FromState = "K_ab", ToState = "Zero", Token = "ab" },
                    new { Character = 'b', FromState = "Zero", ToState = "K_b_bc", Token = (string)null },
                    new { Character = 'c', FromState = "K_b_bc", ToState = "K_bc", Token = (string)null },
                    new { Character = ' ', FromState = "K_bc", ToState = "Zero", Token = "bc" },
                    new { Character = (char)0, FromState = "K_bc", ToState = "Zero", Token = "bc" },
                }, config => config.IncludingAllRuntimeProperties ());
        }

        [Test]
        public void Given_a_keyword_that_contains_another_keyword_When_getting_transitions_Then_the_correct_transitions_are_created()
        {
            var result = CodeGeneration.GetTransitionsForKeywords ("Zero", new[] { "ab", "abc" }).ToArray ();

            result.ShouldBeEquivalentTo (
                new[] { 
                    new { Character = 'a', FromState = "Zero", ToState = "M_a_ab_or_abc", Token = (string)null },
                    new { Character = 'b', FromState = "M_a_ab_or_abc", ToState = "M_ab_ab_or_abc", Token = (string)null },
                    new { Character = ' ', FromState = "M_ab_ab_or_abc", ToState = "Zero", Token = "ab" },
                    new { Character = (char)0, FromState = "M_ab_ab_or_abc", ToState = "Zero", Token = "ab" },
                    new { Character = 'c', FromState = "M_ab_ab_or_abc", ToState = "K_abc", Token = (string)null },
                    new { Character = ' ', FromState = "K_abc", ToState = "Zero", Token = "abc" },
                    new { Character = (char)0, FromState = "K_abc", ToState = "Zero", Token = "abc" },
                }, config => config.IncludingAllRuntimeProperties ());
        }

        [Test]
        public void Given_keywords_starting_wth_the_same_letter_When_getting_transitions_Then_the_correct_transitions_are_created()
        {
            var result = CodeGeneration.GetTransitionsForKeywords ("Zero", new[] { "ab", "ac" }).ToArray ();

            result.ShouldBeEquivalentTo (
                new[] { 
                    new { Character = 'a', FromState = "Zero", ToState = "M_a_ab_or_ac", Token = (string)null },
                    new { Character = 'b', FromState = "M_a_ab_or_ac", ToState = "K_ab", Token =  (string)null },
                    new { Character = ' ', FromState = "K_ab", ToState = "Zero", Token = "ab" },
                    new { Character = (char)0, FromState = "K_ab", ToState = "Zero", Token = "ab" },
                    new { Character = 'c', FromState = "M_a_ab_or_ac", ToState = "K_ac", Token =  (string)null },
                    new { Character = ' ', FromState = "K_ac", ToState = "Zero", Token =  "ac" },
                    new { Character = (char)0, FromState = "K_ac", ToState = "Zero", Token =  "ac" }
                }, config => config.IncludingAllRuntimeProperties ());
        }
    }
}

