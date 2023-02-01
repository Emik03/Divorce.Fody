// SPDX-License-Identifier: MPL-2.0
#if !NETSTANDARD2_0 // ReSharper disable WrongIndentSize
var standardOutput = Func(Console.ReadLine)
   .Forever()
   .Select(Invoke)
   .TakeUntil(string.IsNullOrWhiteSpace);

args
   .Where(File.Exists)
   .DefaultIfEmpty(standardOutput)
   .Select(AssemblyDefinition.ReadAssembly)
   .Filter()
   .Select(Bye.Generics)
   .For(x => x.Write($"Divorce.{x.MainModule?.Name}"));
#endif
