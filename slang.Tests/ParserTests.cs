using NUnit.Framework;
using FluentAssertions;
using Irony.Parsing;
using slang.Parsing;
using System.Collections.Generic;

namespace slang.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        [TestCaseSource("GetTestData")]
        public void Given_some_valid_input_When_parsed_Then_it_should_be_parsed_successfully(string input)
        {
            var parser = new Parser (new SlangGrammar ());
            var result = parser.Parse (input);
            result.ParserMessages.Should ().BeEmpty ();
            result.Root.Should ().NotBeNull ();
        }

        static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData (@"
                package P
                {
                    class A {}
                }
                package P
                {
                    class B {}
                }
            ").Given ("multiple packages");

            yield return new TestCaseData (@"
                package P
                {
                    class A {}
                }
            ").Given ("a simple class declaration");

            yield return new TestCaseData (@"
                package P
                {
                    class A : B {}
                }
            ").Given ("a class declaration which extends a base");

            yield return new TestCaseData (@"
                package P
                {
                    class A : B, C, D {}
                }
            ").Given ("a class declaration which extends multiple bases");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x() = ???
                    }
                }
            ").Given ("a class with an unimplemented function");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x() = {}
                    }
                }
            ").Given ("a class with a function with an empty body");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x() : int = {}
                    }
                }
            ").Given ("a class with a function with a return type");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int) = {}
                    }
                }
            ").Given ("a class with a function with a single parameter");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:string, a2:Object) = {}
                    }
                }
            ").Given ("a class with a function with multiple parameters");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:string, a2:Object) : int = {}
                    }
                }
            ").Given ("a class with a function with multiple parameters and a return value");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x = ???
                    }
                }
            ").Given ("a class with an unimplemented property");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x = { get = ??? }
                    }
                }
            ").Given ("a class with a property with an unimplemented getter");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x = { get = 42 }
                    }
                }
            ").Given("a class with a property with getter that returns a value");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x = { get = 42 set = x = 3 }
                    }
                }
            ").Given("a class with a property with getter and a setter");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x = { get = { x + 42 } set = { x = _ } }
                    }
                }
            ").Given("a class with a property with getter and a setter with function bodies");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x : int = { get = { x + 42 } set = { x = _ } }
                    }
                }
            ").Given("a class with a property with getter and a setter and return type");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:string) : string = { ""name"" }
                    }
                }
            ").Given ("a class with a function that returns a string literal");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { a0 % a1 - a2 }
                    }
                }
            ").Given ("a class with a function that returns the result of an expression");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { y(a0, a1, a2) }
                    }
                }
            ").Given ("a class with a function that returns the result of a function");

            yield return new TestCaseData (@"
                package P
                {
                    trait A : {
                        def x(a0:int, a1:int, a2:int) : int = { a0 + a1 + a2 }
                    }
                }
            ").Given ("a trait with a function that returns the result of an expression");

            yield return new TestCaseData (@"
                package P
                {
                    trait A : B {}
                }
            ").Given ("a trait declaration which extends a base");

            yield return new TestCaseData (@"
                package P
                {
                    object A : {
                        def x(a0:int, a1:int, a2:int) : int = { a0 + a1 + a2 }
                    }
                }
            ").Given ("an object with a function that returns the result of an expression");

            yield return new TestCaseData (@"
                package P
                {
                    object A : B {}
                }
            ").Given ("an object declaration which extends a base");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2: () => int) : int = { a0 % a1 - a2 }
                    }
                }
            ").Given ("a class with a function that takes a lambda that returns a value as a parameter");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2: int => int) : int = { a0 % a1 - a2 }
                    }
                }
            ").Given ("a class with a function that takes a lambda that takes a value and returns an value as a parameter");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { map(b0 => b0 + a0 + a1 + a2) }
                    }
                }
            ").Given ("a class with a function returns the result of function that calls a lambda");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { map(b0 => { b0 + a0 + a1 + a2 }) }
                    }
                }
            ").Given ("a class with a function returns the result of function that calls a lambda with a body");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { map { a0 + a1 + a2 }  }
                    }
                }
            ").Given ("a class with a function returns the result of function that calls a lambda with a body as a block");

            yield return new TestCaseData (@"
                package P
                {
                    class A : {
                        def x(a0:int, a1:int, a2:int) : int = { map(b0) { a0 + a1 + a2 }  }
                    }
                }
            ").Given ("a class with a function returns the result of function with an argument and that calls a lambda with a body as a block");
        }
    }
}

