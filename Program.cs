using System;
using System.Reflection;
using System.IO;

namespace swo_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var pluginFilenames = Directory.GetFiles(@"./plugins", "*.dll");

            foreach(string pluginFilename in pluginFilenames) {
                var pluginPath = Path.GetFullPath(pluginFilename, Directory.GetCurrentDirectory());
                var plugin = Assembly.LoadFile(pluginPath);

                foreach(Type type in plugin.GetExportedTypes()) {
                    dynamic c = Activator.CreateInstance(type);
                    c.Run();
                }
            }

            Console.WriteLine("Done");
        }
    }
}
