using NUnit.Framework;
using FluentAssertions;
using Irony.Parsing;
using slang;
using System.Collections.Generic;

namespace slang.Tests
{

    public static class ParserTestCaseDataExtensions
    {
        public static TestCaseData Given(this TestCaseData testCaseData, string given)
        {
            testCaseData.SetName ("Given " + given + " When parsed Then it should be parsed successfully");
            return testCaseData;
        }
    }
}
