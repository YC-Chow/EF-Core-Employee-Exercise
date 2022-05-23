``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-CREGDX : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|        Method |      Mean |     Error |    StdDev |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|-------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
|    All_Column | 442.54 ms | 15.248 ms | 17.559 ms | 2000.0000 | 1000.0000 | 1000.0000 |    262 MB |
| Select_Column |  84.57 ms |  7.289 ms |  7.799 ms |         - |         - |         - |     60 MB |
