``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-XVNVFJ : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|    Method |         Mean |      Error |     StdDev |      Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|---------- |-------------:|-----------:|-----------:|-----------:|----------:|----------:|----------:|
| NoLoopVer |     51.25 ms |   3.147 ms |   3.624 ms |          - |         - |         - |     36 MB |
|   LoopVer | 10,224.49 ms | 177.281 ms | 189.689 ms | 19000.0000 | 6000.0000 | 1000.0000 |  1,031 MB |
