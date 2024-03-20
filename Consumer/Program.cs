// SPDX-License-Identifier: Unlicense

using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotnetPluginSystemSample;

public class Program {
    static async Task Main(string[] args) {
        Console.WriteLine("Loading plugins...");

        List<IPlugin> loadedPlugins = new();

        var dllFiles = Directory.GetFiles(
            Path.Combine(Directory.GetCurrentDirectory(), "plugins"),
            "*.dll",
            SearchOption.AllDirectories
        );

        foreach (var dll in dllFiles) {
            var assembly = Assembly.LoadFile(dll);
            var pluginsInAssembly = from type in assembly.GetTypes()                                    // of all types found in this assembly...
                                    where type.IsClass &&                                               // select types that are classes
                                          type.GetInterfaces().Select(i => i is IPlugin).Any() &&       //   and inherit IPlugin
                                          !type.IsDefined(typeof(CompilerGeneratedAttribute))           //   and is not compiler-generated (this will filter out async context classes)...
                                    select (IPlugin?)Activator.CreateInstance(type);                    // create instances of these types (may return null if instantiation fails)
            foreach (var plugin in pluginsInAssembly) if (plugin != null) loadedPlugins.Add(plugin);    // collect created IPlugin instances
        }

        Console.WriteLine($"Loaded {loadedPlugins.Count} plugin(s).");

        // plugins are loaded
        foreach (var plugin in loadedPlugins) {
            Console.WriteLine($"Using plugin {plugin.Name}");
            plugin.MakeSound();
            await plugin.GoToSleepAsync();
        }
    }
}