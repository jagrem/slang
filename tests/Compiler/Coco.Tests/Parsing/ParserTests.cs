﻿using System.IO;
using slang.Compiler.Coco.Parsing;
using FluentAssertions;
using slang.Compiler.Core.Parsing.Ast;
using System.Collections.Generic;
using Xunit;

namespace slang.Compiler.Coco.Tests.Parsing
{
    public class ParserTests
    {
        [Fact]
        public void Given_a_simple_module_When_parsed_Then_there_are_no_errors()
        {
            using (var fileStream = File.OpenRead ("./Resources/SimpleModule.sl"))
            {
                var parser = new Parser (new Scanner (fileStream));
                parser.Parse ();
                parser.errors.count.Should ().Be (0);
            }
        }

        [Fact]
        public void Given_a_simple_module_When_parsed_Then_a_module_called_with_the_correct_module_name_is_created ()
        {
            using (var fileStream = File.OpenRead ("./Resources/SimpleModule.sl")) {
                var parser = new Parser (new Scanner (fileStream));
                parser.Parse ();
                var module = parser.Module;
                module.Should ().NotBeNull ();
                module.ModuleDeclaration.ShouldBeEquivalentTo (new { Name = "SimpleModule" });
            }
        }

        [Fact]
        public void Given_a_module_with_bindings_When_parsed_Then_the_correct_bindings_are_created ()
        {
            using (var fileStream = File.OpenRead ("./Resources/ModuleWithBindings.sl")) {
                var parser = new Parser (new Scanner (fileStream));
                parser.Parse ();
                var module = parser.Module;
                module.Bindings.ShouldBeEquivalentTo (new [] {
                    new Binding(new FunctionDeclaration("a", new List<TypeDeclaration> (), null), new Expression(new Literal("123", "System.Int32"))),
                    new Binding(new FunctionDeclaration("b", new List<TypeDeclaration> (), new TypeDeclaration("Int")), new Expression(new Literal("234", "System.Int32")))
                });
            }
        }
    }
}
