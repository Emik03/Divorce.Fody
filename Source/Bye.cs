// SPDX-License-Identifier: MPL-2.0
#if NETSTANDARD2_0 || NET6_0
namespace Divorce.Fody;

using static Enumerable;

/// <summary>Methods to remove elements. These elements cannot be retrieved.</summary>
static class Bye
{
    /// <summary>Removes all nullable attributes of generics in an <see cref="AssemblyDefinition" />.</summary>
    /// <param name="asm">The assembly to mutate.</param>
    /// <returns>The parameter <paramref name="asm" />.</returns>
    internal static AssemblyDefinition Generics(AssemblyDefinition asm)
    {
        asm.Modules
          ?.SelectMany(x => x?.GetAllTypes() ?? Empty<TypeDefinition>())
           .SelectMany(GetAllGenericParameters)
           .Lazily(x => x.ExterminateAllChildMetadata())
           .Enumerate();

        return asm;
    }

    [Pure]
    static IEnumerable<GenericInfo> GetAllGenericParameters(TypeDefinition? x) =>
        x?.Methods?.SelectMany(GenericInfo.From).Concat(GenericInfo.From(x)) ?? Empty<GenericInfo>();
}
#endif
