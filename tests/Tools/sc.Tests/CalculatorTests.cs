using NUnit.Framework;
using System;

namespace sc.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Given_two_integers_When_added_Then_the_result_is_correct()
        {
            dynamic subject = Activator.CreateInstanceFrom (Compiler.CompileFromSource ("Calculator.sl"),"Calculator");
            var result = subject.Add (1, 2);
            result.Should ().Be (3);
        }

        [Test]
        public void Given_two_integers_When_subtracted_Then_the_result_is_correct()
        {
            dynamic subject = Activator.CreateInstanceFrom (Compiler.CompileFromSource ("Calculator.sl"),"Calculator");
            var result = subject.Subtract (7, 5);
            result.Should ().Be (2);
        }
    }
}

