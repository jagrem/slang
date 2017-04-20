using System.IO;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using slang.Compiler.Clr.Compilation.Definitions.Builders;
using slang.Compiler.Clr.Compilation.IL;
using System;
using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Tests.IL
{
    [TestFixture]
    public class GeneratorTests
    {
        Fixture _fixture;
        string _assemblyName;
        string _className;
        string _classNamespace;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture ();
            _assemblyName = _fixture.Create<string> ();
            _className = _fixture.Create<string> ();
            _classNamespace = _fixture.Create<string> ();
        }

        [Test]
        public void Given_an_assembly_definition_for_a_library_When_generating_Then_a_dll_file_is_created()
        {
            // Arrange
            var assemblyDefinition = GetEmptyLibraryDefinition ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var result = new FileInfo (_assemblyName.WithLibraryExtension ());
            result.Exists.Should ().BeTrue ();
        }


        [Test]
        public void Given_an_assembly_definition_for_an_executable_When_generating_Then_an_executable_is_created()
        {
            // Arrange
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsExecutable ()
                .Build();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var result = new FileInfo (_assemblyName.WithExecutableExtension ());
            result.Exists.Should ().BeTrue ();
        }

        [Test]
        public void Given_an_empty_assembly_definition_When_generating_Then_an_assembly_with_the_desired_name_is_created()
        {
            // Arrange
            var assemblyDefinition = GetEmptyLibraryDefinition ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            assemblyDefinition
                .LoadAssembly ()
                .FullName
                .Should ()
                .StartWith (assemblyDefinition.Name);
        }

        [Test]
        public void Given_an_assembly_with_a_module_When_generating_Then_the_assembly_contains_a_module_with_the_same_name_as_the_assembly()
        {
            // Arrange
            var assemblyDefinition = GetEmptyLibraryDefinition ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            assemblyDefinition
                .LoadAssembly ()
                .Modules
                .Should ()
                .Contain (m => m.Name == assemblyDefinition.Filename);
        }

        [Test]
        public void Given_a_class_definition_When_generating_Then_a_class_with_the_correct_name_is_created()
        {
            // Arrange
            var assemblyDefinition = GetAssemblyWithEmptyClassDefinition ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var assembly = assemblyDefinition.LoadAssembly ();
            assembly
                .GetTypes ()
                .Should ()
                    .HaveCount (1)
                .And
                    .Contain (t => t.Name == _className && t.Namespace == _classNamespace);
        }


        [Test]
        public void Given_a_class_definition_When_generating_Then_a_public_static_class_is_created ()
        {
            // Arrange
            var assemblyDefinition = GetAssemblyWithEmptyClassDefinition ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var assembly = assemblyDefinition.LoadAssembly ();
            assembly.GetTypes ().Should ().HaveCount (1);

            var type = assembly.GetTypes ().First ();
            type.IsPublic.Should ().BeTrue ("type must be public");
            type.IsAutoLayout.Should ().BeTrue ("type must be have auto layout");
            type.IsAnsiClass.Should ().BeTrue ("type must be an Ansi class");
            type.IsAbstract.Should ().BeTrue("type must be an abstract class");
            type.IsSealed.Should ().BeTrue ("type must be a sealed class");
            type.Should ().BeDerivedFrom <Object> ("type must extend System.Object");
        }

        [Test]
        public void Given_a_function_definition_When_generating_Then_a_method_with_correct_name_is_created()
        {
            // Arrange
            var methodName = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder.Create (_assemblyName)
                .AsLibrary ()
                .AddModule (c => c
                    .WithName (_className)
                    .WithNamespace (_classNamespace)
                    .AddFunction(f => f
                        .WithName(methodName)
                        .Public ()))
                .Build();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var type = assemblyDefinition.LoadAssembly ().GetTypes ().First ();
            var method = type.GetMethod (methodName);
            method.Should ().NotBeNull ();
        }

        [Test]
        public void Given_a_function_definition_When_generating_Then_a_public_static_method_is_created ()
        {
            // Arrange
            var methodName = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder.Create (_assemblyName)
                .AsLibrary ()
                .AddModule (c => c
                    .WithName (_className)
                    .WithNamespace (_classNamespace)
                    .AddFunction (f => f
                        .WithName (methodName)
                        .Public ()))
                .Build ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var type = assemblyDefinition.LoadAssembly ().GetTypes ().First ();
            var method = type.GetMethod (methodName);
            method.IsPublic.Should ().BeTrue ("method must be public");
            method.IsStatic.Should ().BeTrue ("method must be static");
            method.IsHideBySig.Should ().BeTrue ("method must be hidebysig");
        }

        [Test]
        public void Given_a_function_definition_When_generating_Then_a_simple_method_is_generated()
        {
            // Arrange
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .AddModule (c => c
					.WithName (_className)
					.WithNamespace (_classNamespace)
					.AddFunction (f => f
					     .WithName (methodName)
					     .Public ()))
                .Build ();

            // Act
            Generator.GenerateAssembly (assemblyDefinition);

            // Assert
            var type = assemblyDefinition.LoadAssembly ().GetTypes ().First ();
            var method = type.GetMethod (methodName);
            var result = method.Invoke (null, null);
            result.Should ().BeOfType<int> ();
            result.Should ().Be (1);
        }

        static void DeleteFilesIfTheyExist(params string[] assemblyNames)
        {
            assemblyNames.ToList().ForEach(a => {
                if(File.Exists(a)) {
                    File.Delete (a);
                }
            });
        }

        AssemblyDefinition GetAssemblyWithEmptyClassDefinition ()
        {
            return AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .AddModule (c => c
					.WithName (_className)
					.WithNamespace (_classNamespace))
                .Build ();
        }

        AssemblyDefinition GetEmptyLibraryDefinition ()
        {
            return AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build ();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteFilesIfTheyExist (_assemblyName.WithLibraryExtension (), _assemblyName.WithExecutableExtension ());
        }
    }
}

