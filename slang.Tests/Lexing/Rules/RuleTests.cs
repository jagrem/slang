﻿using NUnit.Framework;
using FluentAssertions;
using slang.Lexing.Trees;
using slang.Lexing.Trees.Nodes;
using slang.Lexing.Rules.Core;
using slang.Lexing.Rules.Extensions;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    public class RuleTests
    {
        [Test]
        public void Given_a_constant_rule_When_converting_to_tree_Then_it_produces_a_list_with_only_one_node ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Constant ('a');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node () {
                Transitions = new Transitions {
                    { 'a', new Terminal () }
                }
            });
        }

        [Test]
        public void Given_a_constant_and_a_constant_When_converting_to_a_tree_Then_it_produces_a_tree_with_one_node_with_one_child_node ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new And ('a', 'b');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (
                new Node {
                    Transitions = new Transitions {
                        { 'a', new Node { Transitions = new Transitions { { 'b', new Terminal() } } } }
                    }
                });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_left_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_two_nodes_with_one_child_each ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new And (new Or ('a', 'b'), 'c');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {'a', new Node { Transitions = new Transitions { { 'c', new Terminal () } } } },
                    {'b', new Node { Transitions = new Transitions { { 'c', new Terminal () } } } }
                }
            });
        }

        [Test]
        public void Given_a_constant_and_a_constant_or_a_constant_right_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_one_node_with_two_child_nodes ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new And ('a', new Or('b', 'c'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {
                        'a',
                        new Node {
                            Transitions = new Transitions {
                                { 'b', new Terminal() },
                                { 'c', new Terminal() }
                            }
                        }
                    }
                }
            });
        }

        [Test]
        public void Given_a_constant_and_a_constant_and_a_constant_left_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_a_branch_three_nodes_deep ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new And (new And ('a', 'b'), 'c');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {
                        'a',
                        new Node {
                            Transitions = new Transitions {
                                {
                                    'b',
                                    new Node {
                                        Transitions = new Transitions {
                                            { 'c', new Terminal () }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        [Test]
        public void Given_a_constant_and_a_constant_and_a_constant_right_associating_When_converting_to_tree_list_Then_it_produces_a_tree_with_a_branch_three_nodes_deep ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new And ('a', new And ('b', 'c'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {
                        'a',
                        new Node {
                            Transitions = new Transitions {
                                {
                                    'b',
                                    new Node {
                                        Transitions = new Transitions {
                                            { 'c', new Node () }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_a_constant_When_converting_to_a_tree_Then_it_produces_a_tree_of_two_child_nodes ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or ('a', 'd');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a', new Terminal() },
                    { 'd', new Terminal() }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_left_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_two_nodes_with_one_with_a_child_node ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or (new And ('a', 'b'), 'c');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a', new Node { Transitions = new Transitions { { 'b', new Terminal() } } } },
                    { 'c', new Terminal() }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_right_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_two_nodes_with_one_with_a_child_node ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or ('a', new And ('b', 'c'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {'a', new Terminal() },
                    {'b', new Node { Transitions = new Transitions { {'c', new Terminal() } } } }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_a_constant_or_a_constant_right_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_three_children ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or ('a', new Or ('b', 'c'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a',new Terminal() },
                    { 'b',new Terminal() },
                    { 'c',new Terminal() }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_a_constant_or_a_constant_left_associating_When_converting_to_a_tree_Then_it_produces_a_tree_with_three_children ()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or (new Or ('a', 'b'), 'c');

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a', new Terminal() },
                    { 'b', new Terminal() },
                    { 'c', new Terminal() }
                }
            });
        }

        [Test]
        public void Given_multiple_input_values_When_converting_to_a_tree_Then_only_one_transition_is_produced()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or ('a', new Or ('b', 'a'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a', new Terminal () },
                    { 'b', new Terminal () }
                }
            });
        }

        [Test]
        public void Given_a_constant_and_an_optional_constant_When_converting_to_a_tree_Then_the_tree_two_terminal_nodes()
        {
            var rule = new And ('a', new Option ('b'));

            var result = LexicalTreeBuilder.Build (rule);

            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a',new Terminal{Transitions = new Transitions { { 'b', new Terminal () } } } }
                }
            });
        }

        [Test]
        public void Given_an_optional_constant_and_a_constant_When_converting_to_a_tree_Then_there_are_two_paths_to_the_final_constant ()
        {
            var rule = new And (new Option ('b'), 'a');

            var result = LexicalTreeBuilder.Build (rule);

            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'b', new Node { Transitions = new Transitions { { 'a', new Terminal() } } } },
                    { 'a', new Terminal() }
                }
            });
        }

        [Test]
        public void Given_a_constant_or_an_optional_constant_When_converting_to_a_tree_Then_the_tree_two_terminal_nodes ()
        {
            var rule = new Or ('a', new Option ('b'));

            var result = LexicalTreeBuilder.Build (rule);

            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    { 'a',new Terminal{Transitions = new Transitions { { 'b', new Terminal () } } } }
                }
            });
        }

        [Test]
        public void Given_a_more_complex_rule_When_converting_to_a_tree_Then_it_produces_the_correct_tree()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var rule = new Or (
                new And (
                    'a',
                    new Or ('b', 'c')),
                new And (
                    new And ('e', new Or ('f', 'g')),
                    'd'));

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            var result = LexicalTreeBuilder.Build (rule);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            result.ShouldBeEquivalentTo (new Node {
                Transitions = new Transitions {
                    {
                        'a',
                        new Node {
                            Transitions = new Transitions {
                                { 'b', new Terminal() },
                                { 'c', new Terminal() }
                            }
                        }
                    },
                    {
                        'e',
                        new Node {
                            Transitions = new Transitions {
                                { 'f', new Node { Transitions = new Transitions { { 'd', new Terminal() } } } },
                                { 'g', new Node { Transitions = new Transitions { { 'd', new Terminal() } } } }
                            }
                        }
                    }
                }
            });
        }
    }
}
