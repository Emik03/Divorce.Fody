#region Emik.MPL

// <copyright file="ModuleWeaver.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

#endregion

#if NETSTANDARD2_0
namespace Divorce.Fody;

#region

using static Enumerable;

#endregion

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
