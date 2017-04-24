using slang.Compiler.Clr.Compilation.Core.Builders;
using slang.Compiler.Clr.Compilation.CSharp;
using Xunit;

namespace Clr.Tests.Compilation.CSharp
{
    public class CSharpAssemblyGeneratorTests
    {
        [Fact]
        public void Given_a_defined_module_When_compiled_Then_a_CLR_class_is_created()
        {
            // Arrange
            var subject = new CSharpAssemblyGenerator();
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create("slang")
                .AsLibrary()
                .AddModule(m => m.WithName("CSharpAssemblyGeneratorTestModule").WithNamespace("slang.Clr.Tests"))
                .Build();

            // Act
            var result = subject.GenerateDynamicAssembly(assemblyDefinition);

            // Assert
            result.GetType("slang.Clr.Tests.CSharpAssemblyGeneratorTestModule", true);
        }
    }
}
