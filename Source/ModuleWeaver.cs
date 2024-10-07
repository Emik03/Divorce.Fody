// SPDX-License-Identifier: MPL-2.0
#if NETSTANDARD2_0
namespace Divorce.Fody;

/// <summary>This weaver moves NRTs away from generic constraints.</summary>
[CLSCompliant(false)]
public sealed class ModuleWeaver : BaseModuleWeaver
{
    /// <inheritdoc />
    public override bool ShouldCleanReference => false;

    /// <inheritdoc />
    public override void Execute()
    {
        static bool IsIgnored(AssemblyNameReference x) => x is not { Name: "mscorlib" };

        if (ModuleDefinition.Assembly is not { } asm)
            WriteError("Definition lacks assembly.");
        else if (ModuleDefinition.AssemblyReferences.OrEmpty().All(IsIgnored))
            WriteInfo("No weaving required.");
        else
            Bye.Generics(asm, WriteDebug);
    }

    /// <inheritdoc />
    public override IEnumerable<string> GetAssembliesForScanning() => [];
}
#endif
