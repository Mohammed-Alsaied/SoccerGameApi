namespace Common
{
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class AssemblyExtentions
    {
        public static Assembly[] GetReferencedAssemblies(Assembly assembly, string searchPattern)
        {
            string[] files = Directory.GetFiles(new FileInfo(assembly.Location).DirectoryName, searchPattern);
            return files?.Select(e => Assembly.LoadFrom(e)).ToArray();
        }
    }
}