#region Emik.MPL

// <copyright file="InlineAttribute.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

#endregion

// ReSharper disable once CheckNamespace
namespace InlineMethod;

#region

using static AttributeTargets;

#endregion

/// <summary>Method to inline.</summary>
[AttributeUsage(Method)]
sealed class InlineAttribute : Attribute
{
    /// <summary>Initializes a new instance of the <see cref="InlineAttribute" /> class.</summary>
    /// <param name="remove">The value to set.</param>
    public InlineAttribute(bool remove = true) => Remove = remove;

    /// <summary>Gets a value indicating whether to remove the method after inlining, if private.</summary>
    public bool Remove { get; }
}
