// SPDX-License-Identifier: MPL-2.0
#if !NETSTANDARD2_0
// ReSharper disable WrongIndentSize
var standardOutput =
    Func(Console.ReadLine)
       .Forever()
       .Select(Invoke)
       .TakeUntil(string.IsNullOrWhiteSpace);

args
   .DefaultIfEmpty(standardOutput)
   .Where(File.Exists)
   .Select(AssemblyDefinition.ReadAssembly)
   .Filter()
   .Select(Bye.Generics)
   .For(x => x.Write($"Divorce.{x.MainModule?.Name}"));
#endif
