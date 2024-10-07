// SPDX-License-Identifier: MPL-2.0
namespace Divorce.Fody;

/// <summary>Methods to remove nullable attributes on generics.</summary>
static class Bye
{
    /// <summary>Removes all nullable attributes of generics in an <see cref="AssemblyDefinition" />.</summary>
    /// <param name="asm">The assembly to mutate.</param>
    /// <param name="logger">The logger to use.</param>
    /// <returns>The parameter <paramref name="asm" />.</returns>
    internal static AssemblyDefinition Generics(AssemblyDefinition asm, Action<string> logger)
    {
        asm.Modules
           .ManyOrEmpty(x => x.GetAllTypes())
           .Filter()
           .SelectMany(x => x.Methods.OrEmpty().SelectMany(GenericInfo.From).Concat(GenericInfo.From(x)))
           .Lazily(x => x.ExterminateAllChildMetadata(logger))
           .Enumerate();

        return asm;
    }
}
