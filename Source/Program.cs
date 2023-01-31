// SPDX-License-Identifier: MPL-2.0
#if !NETSTANDARD2_0
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
