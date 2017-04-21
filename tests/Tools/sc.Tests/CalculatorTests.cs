using System.Reflection;
using Xunit;

namespace sc.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Given_two_integers_When_added_Then_the_result_is_correct()
        {
            dynamic subject = Assembly.GetEntryAssembly ().CreateInstance ("Calculator");
            var result = subject.Add (1, 2);
            result.Should ().Be (3);
        }

        [Fact]
        public void Given_two_integers_When_subtracted_Then_the_result_is_correct()
        {
            dynamic subject = Assembly.GetEntryAssembly ().CreateInstance ("Calculator");
            var result = subject.Subtract (7, 5);
            result.Should ().Be (2);
        }
    }
}

