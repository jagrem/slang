using System.IO;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using slang.Compiler.Clr.Compilation.Definitions.Builders;
using slang.Compiler.Clr.Compilation.IL;
using System;

namespace slang.Tests.IL
{
    [TestFixture]
    public class GeneratorTests
    {
        Fixture _fixture;
        string _assemblyName;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture ();
            _assemblyName = _fixture.Create<string> ();
        }

        [Test]
        public void Given_an_assembly_definition_for_a_library_When_generating_Then_a_dll_file_is_created()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            var result = new FileInfo (_assemblyName.WithLibraryExtension ());
            result.Exists.Should ().BeTrue ();
        }

        [Test]
        public void Given_an_assembly_definition_for_an_executable_When_generating_Then_an_executable_is_created()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsExecutable ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            var result = new FileInfo (_assemblyName.WithExecutableExtension ());
            result.Exists.Should ().BeTrue ();
        }

        [Test]
        public void Given_an_empty_assembly_definition_When_generating_Then_an_assembly_with_the_desired_name_is_created()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            assemblyDefinition
                .LoadAssembly ()
                .FullName
                .Should ()
                .StartWith (assemblyDefinition.Name);
        }

        [Test]
        public void Given_an_assembly_with_a_module_When_generating_Then_the_assembly_contains_a_module_with_the_same_name_as_the_assembly()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            assemblyDefinition
                .LoadAssembly ()
                .Modules
                .Should ()
                .Contain (m => m.Name == assemblyDefinition.Filename);
        }

        [Test]
        public void Given_a_class_definition_When_generating_Then_a_class_with_the_correct_name_is_created()
        {
            var className = _fixture.Create<string>();
            var classNamespace = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .AddClass (c => c
                           .WithName (className)
                           .WithNamespace (classNamespace)
                           .Public ())
                .Build ();

            Generator.GenerateAssembly (assemblyDefinition);

            var assembly = assemblyDefinition.LoadAssembly ();
            assembly
                .GetTypes ()
                .Should ()
                    .HaveCount (1)
                .And
                    .Contain (t => t.Name == className && t.Namespace == classNamespace);
        }

        [Test]
        public void Given_a_class_definition_When_generating_Then_a_public_static_class_is_created ()
        {
            var className = _fixture.Create<string> ();
            var classNamespace = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .AddClass (c => c
                           .WithName (className)
                           .WithNamespace (classNamespace)
                           .Public ())
                .Build ();

            Generator.GenerateAssembly (assemblyDefinition);

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
            var methodName = _fixture.Create<string> ();
            var className = _fixture.Create<string> ();
            var classNamespace = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder.Create (_assemblyName)
                .AsLibrary ()
                .AddClass (c => c
                    .WithName (className)
                           .WithNamespace (classNamespace)
                           .Public()
                           .AddFunction(f => f
                                        .WithName(methodName)
                                        .Public ()))
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            var type = assemblyDefinition.LoadAssembly ().GetTypes ().First ();
            var method = type.GetMethod (methodName);
            method.Should ().NotBeNull ();
        }

        [Test]
        public void Given_a_function_definition_When_generating_Then_a_public_static_method_is_created ()
        {
            var methodName = _fixture.Create<string> ();
            var className = _fixture.Create<string> ();
            var classNamespace = _fixture.Create<string> ();
            var assemblyDefinition = AssemblyDefinitionBuilder.Create (_assemblyName)
                .AsLibrary ()
                .AddClass (c => c
                    .WithName (className)
                           .WithNamespace (classNamespace)
                           .Public ()
                           .AddFunction (f => f
                                         .WithName (methodName)
                                         .Public ()))
                .Build ();

            Generator.GenerateAssembly (assemblyDefinition);

            var type = assemblyDefinition.LoadAssembly ().GetTypes ().First ();
            var method = type.GetMethod (methodName);
            method.IsPublic.Should ().BeTrue ("method must be public");
            method.IsStatic.Should ().BeTrue ("method must be static");
            method.IsHideBySig.Should ().BeTrue ("method must be hidebysig");
        }


        static void DeleteFilesIfTheyExist(params string[] assemblyNames)
        {
            assemblyNames.ToList().ForEach(a => {
                if(File.Exists(a)) {
                    File.Delete (a);
                }
            });
        }

        [TearDown]
        public void TearDown()
        {
            DeleteFilesIfTheyExist (_assemblyName.WithLibraryExtension (), _assemblyName.WithExecutableExtension ());
        }
    }
}

