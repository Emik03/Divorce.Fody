// <copyright file="Program.cs" company="Emik">
// Copyright (c) Emik. This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>
#if NET6_0
Func(Console.ReadLine)
   .Forever()
   .Select(Invoke)
   .TakeUntil(string.IsNullOrWhiteSpace)
   .Where(File.Exists)
   .Select(AssemblyDefinition.ReadAssembly)
   .Filter()
   .Select(Bye.Generics)
   .For(x => x.Write($"Divorce.{x.MainModule?.Name}"));
#endif
