``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|     Method |    Mean |   Error |  StdDev |     Gen 0 | Allocated |
|----------- |--------:|--------:|--------:|----------:|----------:|
| No_Pooling | 24.82 s | 0.410 s | 0.383 s | 6000.0000 |    340 MB |
|    Pooling | 23.77 s | 0.199 s | 0.186 s | 5000.0000 |    258 MB |
