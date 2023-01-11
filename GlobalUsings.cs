#region Emik.MPL

// <copyright file="GlobalUsings.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

#endregion

#region

#if NET6_0
global using Divorce.Fody;
#elif !NET20
global using Fody;
#endif

#if !NET20
global using Mono.Cecil;
global using Mono.Cecil.Rocks;
global using IMonoProvider = Mono.Cecil.ICustomAttributeProvider;
#endif

#endregion
