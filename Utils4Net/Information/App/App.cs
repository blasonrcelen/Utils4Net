using System.Reflection;

namespace Utils4Net.Information.App
{
    public class App
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Version? Version { get; set; }

        public App(Type type) : this(Assembly.GetAssembly(type))
        {
        }

        public App(Assembly? assembly)
        {
            if (string.IsNullOrWhiteSpace(assembly?.GetName()?.Name))
            {
                throw new ArgumentException("App name is not defined");
            }

            Name = assembly.GetName().Name;
            Description = assembly?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            Version = assembly?.GetName()?.Version;
        }

        public App(string name, string? description = null, uint major = 0, uint minor = 0, uint build = 0, uint revision = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Description = description;
            Version = new Version((int)major, (int)minor, (int)build, (int)revision);
        }

        public App(string name, string? description = null, Version? version = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Description = description;
            Version = version;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Version);
        }
    }
}
