``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-PGRVIA : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|  Method |    Mean |    Error |   StdDev |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|-------- |--------:|---------:|---------:|----------:|----------:|----------:|----------:|
| NoSplit | 2.208 s | 0.0261 s | 0.0173 s | 9000.0000 | 6000.0000 | 4000.0000 |    912 MB |
|   Split | 2.193 s | 0.0419 s | 0.0350 s | 8000.0000 | 5000.0000 | 3000.0000 |    923 MB |
