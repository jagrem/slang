namespace sc.Options
{
    public class Project
    {
        public string Name { get; }
        public string Version { get; }
        public string Description { get; }
        public string Copyright { get; }
        public string Title { get; }
        public string EntryPoint { get; }
        public Dependency [] Dependencies { get; }
    }

    public class Dependency
    {
        public string Name { get; }
        public string Type { get; }
        public string Version { get; }
    }
}
