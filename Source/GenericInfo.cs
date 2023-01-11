#region Emik.MPL

// <copyright file="GenericInfo.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

#endregion

#if !NET20
namespace Divorce.Fody;

#region

using static Enumerable;

#endregion

/// <summary>Stores temporary information regarding a <see cref="GenericParameter" />.</summary>
/// <param name="Generic">The generic parameter.</param>
/// <param name="Provider">The parent member, either a method or type.</param>
sealed record GenericInfo(GenericParameter? Generic, IMonoProvider? Provider)
{
    const string Null = "System.Runtime.CompilerServices.NullableAttribute";

    /// <summary>Creates new instances of <see cref="GenericInfo" /> lazily.</summary>
    /// <param name="x">The argument with generic parameters to create an iterable from.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> of itself.</returns>
    [Pure]
    internal static IEnumerable<GenericInfo> From(IGenericParameterProvider? x) =>
        x?.GenericParameters?.Select(y => new GenericInfo(y, x as IMonoProvider)) ?? Empty<GenericInfo>();

    /// <summary>Removes the nullability attributes of a generic and passes it to <see cref="Provider" />.</summary>
    internal void ExterminateAllChildMetadata()
    {
        var providerAttributes = Provider?.CustomAttributes ?? new();

        IEnumerable<bool> ExterminateMetadata(ICollection<CustomAttribute?>? collection) =>
            collection
              ?.Where(x => x?.AttributeType?.FullName is Null)
               .For(providerAttributes.Add)
               .Select(collection.Remove) ??
            Empty<bool>();

        Generic
          ?.Constraints
          ?.Select(x => x?.CustomAttributes)
           .SelectMany(ExterminateMetadata)
           .Enumerate();
    }
}
#endif
