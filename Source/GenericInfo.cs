// SPDX-License-Identifier: MPL-2.0
namespace Divorce.Fody;

/// <summary>Stores temporary information regarding a <see cref="GenericParameter" />.</summary>
/// <param name="Generic">The generic parameter.</param>
/// <param name="Provider">The parent member, either a method or type.</param>
sealed record GenericInfo(GenericParameter? Generic, IMonoProvider? Provider)
{
    /// <summary>Creates new instances of <see cref="GenericInfo" /> lazily.</summary>
    /// <param name="x">The argument with generic parameters to create an iterable from.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> of itself.</returns>
    [Pure]
    internal static IEnumerable<GenericInfo> From(IGenericParameterProvider? x) =>
        x?.GenericParameters.OrEmpty().Select(y => new GenericInfo(y, x as IMonoProvider)) ?? [];

    /// <summary>Removes the nullability attributes of a generic and passes it to <see cref="Provider" />.</summary>
    /// <param name="logger">The logger to use.</param>
    internal void ExterminateAllChildMetadata(Action<string> logger)
    {
        var providerAttributes = Provider?.CustomAttributes ?? [];

        IEnumerable<bool> ExterminateMetadata(ICollection<CustomAttribute?> collection) =>
            collection
               .Where(x => x is { AttributeType.FullName: "System.Runtime.CompilerServices.NullableAttribute" })
               .Lazily(providerAttributes.Add)
               .Lazily(x => logger($"Moving {x?.Constructor} to {Provider}."))
               .ToIList()
               .Select(collection.Remove);

        Generic
          ?.Constraints
           .OrEmpty()
           .Filter()
           .Select(x => x.CustomAttributes)
           .Filter()
           .SelectMany(ExterminateMetadata)
           .Enumerate();
    }
}
