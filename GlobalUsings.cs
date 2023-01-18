// SPDX-License-Identifier: MPL-2.0
#if NET6_0
global using Divorce.Fody;
#elif NETSTANDARD2_0
global using Fody;
#endif

#if NETSTANDARD2_0 || NET6_0
global using Mono.Cecil;
global using Mono.Cecil.Rocks;
global using IMonoProvider = Mono.Cecil.ICustomAttributeProvider;
#endif
