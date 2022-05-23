``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-QYJMFV : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=200  MinIterationCount=100  

```
|        Method |     Mean |   Error |   StdDev |     Gen 0 | Allocated |
|-------------- |---------:|--------:|---------:|----------:|----------:|
| With_Tracking | 392.2 ms | 8.95 ms | 37.90 ms |         - |    262 MB |
|   No_Tracking | 121.4 ms | 3.71 ms | 15.70 ms | 1000.0000 |     74 MB |
