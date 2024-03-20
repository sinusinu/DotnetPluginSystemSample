// SPDX-License-Identifier: Unlicense

namespace DotnetPluginSystemSample;

public interface IPlugin {
    public string Name { get; }

    public void MakeSound();
    public Task GoToSleepAsync();
}
