// SPDX-License-Identifier: Unlicense

namespace DotnetPluginSystemSample;

public class DogPlugin : IPlugin {
    public string Name => "Dog";

    public DogPlugin() {}

    public void MakeSound() {
        Console.WriteLine("woof woof");
    }

    public async Task GoToSleepAsync() {
        await Task.Delay(500);
        Console.WriteLine("The dog has fallen asleep");
    }
}
