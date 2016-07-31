using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using slang.Compiler.Clr.Compilation.Definitions.Builders;
using slang.Compiler.Clr.Compilation.IL;

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
        public void Given_an_assembly_definition_When_generating_Then_a_valid_assembly_is_created()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            var result = LoadAssembly(_assemblyName);
            result
                .FullName
                .Should ()
                .StartWith (assemblyDefinition.Name);
        }

        [Test]
        public void Given_an_assembly_with_a_module_When_generating_Then_the_module_is_created()
        {
            var assemblyDefinition = AssemblyDefinitionBuilder
                .Create (_assemblyName)
                .AsLibrary ()
                .Build();

            Generator.GenerateAssembly (assemblyDefinition);

            var result = LoadAssembly(_assemblyName);
            result
                .Modules
                .Should ()
                .Contain (m => m.Name == assemblyDefinition.Filename);
        }

        [Test]
        public void Given_a_class_definition_When_generating_Then_a_public_class_is_created()
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

            TypesDefinedInAssembly
                .Should ()
                    .HaveCount(1)
                .And
                .Contain (t => t.Name == className && t.IsPublic && t.Namespace == classNamespace);
        }

        [Test]
        public void Given_a_function_definition_When_generating_Then_a_method_is_created()
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

            TypesDefinedInAssembly
                .Should ()
                    .HaveCount (1)
                .And
                    .Contain (t => t.GetMethod(methodName) != null);
        }

        Type[] TypesDefinedInAssembly
        {
            get { return LoadAssembly (_assemblyName).GetTypes (); }
        }

        static Assembly LoadAssembly(string assemblyName)
        {
            return AppDomain.CurrentDomain.Load (new AssemblyName (assemblyName));
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

    static class StringExtensions
    {
        public static string WithLibraryExtension(this string assemblyName)
        {
            return assemblyName + ".dll";
        }

        public static string WithExecutableExtension(this string assemblyName)
        {
            return assemblyName + ".exe";
        }
    }
}

