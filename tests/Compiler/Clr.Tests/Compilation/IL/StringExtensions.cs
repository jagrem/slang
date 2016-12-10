namespace slang.Tests.IL
{
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
