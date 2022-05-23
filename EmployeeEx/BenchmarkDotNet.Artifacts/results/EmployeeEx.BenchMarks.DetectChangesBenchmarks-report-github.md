``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-PPKCSP : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|            Method |     Mean |    Error |   StdDev |     Gen 0 | Allocated |
|------------------ |---------:|---------:|---------:|----------:|----------:|
|    WithAutoDetect | 504.4 ms | 11.28 ms | 12.99 ms | 1000.0000 |    110 MB |
| WithoutAutoDetect | 498.6 ms |  6.66 ms |  3.48 ms | 1000.0000 |    110 MB |
