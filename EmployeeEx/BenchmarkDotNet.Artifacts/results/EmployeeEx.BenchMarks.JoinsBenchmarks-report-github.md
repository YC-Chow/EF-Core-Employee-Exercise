``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  Job-EDFDSA : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

MaxIterationCount=20  MinIterationCount=10  

```
|                           Method |      Mean |    Error |   StdDev | Allocated |
|--------------------------------- |----------:|---------:|---------:|----------:|
|  GetEmployeeByZipCodeLeftJoinVer | 113.56 ms | 3.588 ms | 4.132 ms |  3,034 KB |
| GetEmployeeByZipCodeInnerJoinVer |  59.77 ms | 1.193 ms | 0.862 ms |    405 KB |
