``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-AIJWTW : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|                             Method |     Mean |     Error |    StdDev |   Median | Allocated |
|----------------------------------- |---------:|----------:|----------:|---------:|----------:|
| GetAllEmployeeWhereBeforeToListVer | 1.977 ms | 0.8278 ms | 0.9200 ms | 1.505 ms |    122 KB |
|  GetAllEmployeeWhereAfterToListVer | 5.330 ms | 0.8364 ms | 0.9297 ms | 5.020 ms |  1,735 KB |
