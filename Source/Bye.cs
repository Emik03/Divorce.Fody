#region Emik.MPL

// <copyright file="Bye.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

#endregion

#if NETSTANDARD2_0 || NET6_0
namespace Divorce.Fody;

#region

using static Enumerable;

#endregion

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
