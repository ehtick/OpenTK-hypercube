using Hypercube.Utilities.Arguments;

namespace Hypercube.Core.Execution;

public partial class Runtime
{
    private readonly ArgumentParser _parser = new ArgumentParser()
        .AddFlag(RuntimeArguments.ConfigDontInit);
}