﻿// SPDX-License-Identifier: MPL-2.0
#if !NETSTANDARD2_0
var readLine = Console.ReadLine;

args
   .DefaultIfEmpty(readLine.Forever().Select(Invoke).TakeUntil(string.IsNullOrWhiteSpace))
   .Where(File.Exists)
   .Select(AssemblyDefinition.ReadAssembly)
   .Filter()
   .Select(Bye.Generics)
   .Lazily(x => x.Write($"Divorce.{x.MainModule?.Name}"))
   .Enumerate();
#endif
