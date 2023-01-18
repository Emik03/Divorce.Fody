// SPDX-License-Identifier: MPL-2.0
#if NETSTANDARD2_0
namespace Divorce.Fody;

using static Enumerable;

/// <summary>This weaver moves NRTs away from generic constraints.</summary>
[CLSCompliant(false)]
public sealed class ModuleWeaver : BaseModuleWeaver
{
    /// <inheritdoc />
    public override bool ShouldCleanReference => false;

    /// <inheritdoc />
    public override void Execute()
    {
        WriteInfo(typeof(ModuleWeaver).Namespace);

        if (ModuleDefinition.Assembly is { } asm)
            Bye.Generics(asm);
        else
            WriteError("Failed to get assembly for weaving");
    }

    /// <inheritdoc />
    public override IEnumerable<string> GetAssembliesForScanning() => Empty<string>();
}
#endif
