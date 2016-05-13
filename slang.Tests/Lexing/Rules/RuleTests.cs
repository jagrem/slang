using NUnit.Framework;
using FluentAssertions;
using slang.Lexing.Rules;

namespace slang.Tests.Lexing.Rules
{
    [TestFixture]
    public class RuleTests
    {
        [Test]
        public void Given_a_constant_rule_When_converting_to_a_node_list_Then_it_produces_a_list_with_only_one_node()
        {
            var rule = new ConstantRule ('a');
            var result = rule.GetNodeList();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode () });
        }

        [Test]
        public void Given_a_constant_and_a_constant_rule_When_converting_to_a_node_list_Then_it_produces_a_list_with_one_node_with_one_child_node ()
        {
            var rule = new AndRule('a', 'b');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (new [] { new LexicalNode () }) });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_left_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_two_nodes_with_one_child_each ()
        {
            var rule = new AndRule (new OrRule ('a', 'b'), 'c');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (new [] { new LexicalNode () }), new LexicalNode(new [] { new LexicalNode () }) });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_right_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_one_node_with_two_child_nodes ()
        {
            var rule = new AndRule ('a', new OrRule('b', 'c'));
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (new [] { new LexicalNode (), new LexicalNode () }) });
        }

        [Test]
        public void Given_a_constant_and_a_constant_and_a_constant_left_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_two_nodes_with_one_child_each ()
        {
            var rule = new AndRule (new AndRule ('a', 'b'), 'c');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (new [] { new LexicalNode (new [] { new LexicalNode () }) }) });
        }

        [Test]
        public void Given_a_constant_and_a_constant_and_a_constant_right_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_two_nodes_with_one_child_each ()
        {
            var rule = new AndRule ('a', new AndRule ('b', 'c'));
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (new [] { new LexicalNode (new [] { new LexicalNode () }) }) });
        }

        [Test]
        public void Given_a_constant_or_a_constant_When_converting_to_a_node_list_Then_it_produces_a_list_of_two_nodes ()
        {
            var rule = new OrRule ('a', 'd');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (), new LexicalNode () });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_left_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_two_nodes_with_one_with_a_child_node ()
        {
            var rule = new OrRule (new AndRule ('a', 'b'), 'c');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (), new LexicalNode (new [] { new LexicalNode () }) });
        }

        [Test]
        public void Given_a_constant_or_a_constant_and_a_constant_right_associating_When_converting_to_a_node_list_Then_it_produces_a_list_with_two_nodes_with_one_with_a_child_node ()
        {
            var rule = new OrRule ('a', new AndRule ('b', 'c'));
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (), new LexicalNode (new [] { new LexicalNode () }) });
        }

        [Test]
        public void Given_a_constant_or_a_constant_or_a_constant_right_associating_When_converting_to_a_node_list_Then_it_produces_a_list_of_three_nodes ()
        {
            var rule = new OrRule ('a', new OrRule ('b', 'c'));
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (), new LexicalNode (), new LexicalNode () });
        }

        [Test]
        public void Given_a_constant_or_a_constant_or_a_constant_left_associating_When_converting_to_a_node_list_Then_it_produces_a_list_of_three_nodes ()
        {
            var rule = new OrRule (new OrRule ('a', 'b'), 'c');
            var result = rule.GetNodeList ();
            result.ShouldBeEquivalentTo (new [] { new LexicalNode (), new LexicalNode (), new LexicalNode () });
        }
    }
}
