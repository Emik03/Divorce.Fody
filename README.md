# Divorce.Fody

[![NuGet package](https://img.shields.io/nuget/v/Divorce.Fody.svg?color=50fa7b&logo=NuGet&style=for-the-badge)](https://www.nuget.org/packages/Divorce.Fody)
[![License](https://img.shields.io/github/license/Emik03/Divorce.Fody.svg?color=6272a4&style=for-the-badge)](https://github.com/Emik03/Divorce.Fody/blob/main/LICENSE)

This is an add-in for [Fody](https://github.com/Fody/Fody) which lets you use Nullable Reference Types in older Mono frameworks (e.g. Unity 2017). Named after an antonym of Unity, since this project bends libraries to conform it.

This project has a dependency to [Emik.Morsels](https://github.com/Emik03/Emik.Morsels), if you are building this project, refer to its [README](https://github.com/Emik03/Emik.Morsels/blob/main/README.md) first.

---

- [Installation](#installation)
- [Example](#example)
- [Contribute](#contribute)
- [License](#license)

---

## Installation

- Install the NuGet packages [`Fody`](https://www.nuget.org/packages/Fody) and [`Divorce.Fody`](https://www.nuget.org/packages/Divorce.Fody). Installing `Fody` explicitly is needed to enable weaving.

  ```
  PM> Install-Package Fody
  PM> Install-Package Divorce.Fody
  ```

- Add the `PrivateAssets="all"` metadata attribute to the `<PackageReference />` items of `Fody` and `Divorce.Fody` in your project file, so they won't be listed as dependencies.

- If you already have a `FodyWeavers.xml` file in the root directory of your project, add the `<Divorce />` tag there. This file will be created on the first build if it doesn't exist:

```xml
<Weavers>
    <Divorce />
</Weavers>
```

See [Fody usage](https://github.com/Fody/Home/blob/master/pages/usage.md) for general guidelines, and [Fody Configuration](https://github.com/Fody/Home/blob/master/pages/configuration.md) for additional options.

## Example

What you write:

```csharp
#nullable enable
interface I { }
class C : I { }
class D<T> where T : C { }
```

What gets compiled:

```csharp
#nullable enable
interface I { }
class C : 
#nullable disable
    I
#nullable enable
{ }
class D<T> where T :
#nullable disable
    C
#nullable enable
{ }
```

## Contribute

Issues and pull requests are welcome to help this repository be the best it can be.

## License

This repository falls under the [MPL-2 license](https://www.mozilla.org/en-US/MPL/2.0/).
