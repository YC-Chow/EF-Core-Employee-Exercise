``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-UAHIYK : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|    Method |     Mean |    Error |   StdDev | Allocated |
|---------- |---------:|---------:|---------:|----------:|
| NoOrderBy | 187.4 ms | 10.11 ms | 10.81 ms |    128 MB |
|   OrderBy | 197.4 ms | 11.23 ms | 12.93 ms |    128 MB |
