// SPDX-License-Identifier: Unlicense

namespace DotnetPluginSystemSample;

public class CatPlugin : IPlugin {
    public string Name => "Cat";

    public CatPlugin() {}

    public void MakeSound() {
        Console.WriteLine("meow");
    }

    public async Task GoToSleepAsync() {
        await Task.Delay(500);
        Console.WriteLine("The cat has fallen asleep");
    }
}
