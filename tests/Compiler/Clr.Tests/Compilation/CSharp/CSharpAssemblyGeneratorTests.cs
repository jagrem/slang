using System.Reflection;
using FluentAssertions;
using slang.Compiler.Clr.Compilation.Core.Builders;
using slang.Compiler.Clr.Compilation.CSharp;
using Xunit;
using System;

namespace Clr.Tests.Compilation.CSharp
{
    public class CSharpAssemblyGeneratorTests
    {
        string CreateAnonymousAssemblyName() => "slang" + Guid.NewGuid().ToString();

        [Fact]
        public void Given_a_defined_module_When_compiled_Then_a_corresponding_public_class_is_created()
        {
            // Arrange
            var subject = new CSharpAssemblyGenerator();
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create(CreateAnonymousAssemblyName())
                .AsLibrary()
                .AddModule(m => m
                    .WithName("CSharpAssemblyGeneratorTestModule")
                    .WithNamespace("slang.Clr.Tests"))
                .Build();

            // Act
            var result = subject.GenerateDynamicAssembly(assemblyDefinition);

            // Assert
            var typeInfo = result.GetType("slang.Clr.Tests.CSharpAssemblyGeneratorTestModule", true).GetTypeInfo();
            typeInfo.IsPublic.Should().BeTrue();
        }

        [Fact]
        public void Given_a_parameterless_function_returning_a_constant_When_compiled_Then_a_corresponding_method_is_created()
        {
            var subject = new CSharpAssemblyGenerator();
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create(CreateAnonymousAssemblyName())
                .AsLibrary()
                .AddModule(m => m
                    .WithName("CSharpAssemblyGeneratorTestModule")
                    .WithNamespace("slang.Clr.Tests")
                    .AddFunction(f => f
                        .Public()
                        .WithName("Add")
                        .WithBody("return 0;")
                        .WithReturnType("System.Int32")))
                .Build();

            // Act
            var result = subject.GenerateDynamicAssembly(assemblyDefinition);

            // Assert
            var typeInfo = result.GetType("slang.Clr.Tests.CSharpAssemblyGeneratorTestModule", true).GetTypeInfo();
            var methodInfo = typeInfo.GetMethod("Add");
            methodInfo.Should().NotBeNull("because the Add method should be created");

            var parameters = methodInfo.GetParameters();
            parameters.Should().BeEmpty("because the Add method should have no parameters");

            var returnType = methodInfo.ReturnType;
            returnType.Should().Be<int>("because the Add method should return an integer");
        }
    }
}
