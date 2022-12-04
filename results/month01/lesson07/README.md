``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.100
  [Host] : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Toolchain=InProcessEmitToolchain  InvocationCount=1  IterationCount=1  
IterationTime=500.0000 ms  LaunchCount=1  RunStrategy=ColdStart  
UnrollFactor=1  WarmupCount=0  

```
|          Method |   Size |           Mean | Error |  Ratio |
|---------------- |------- |---------------:|------:|-------:|
| **ArraySortDotnet** |    **100** |       **176.3 μs** |    **NA** |   **1.00** |
|      SelectSort |    100 |       580.8 μs |    NA |   3.29 |
|        HeapSort |    100 |       368.2 μs |    NA |   2.09 |
|                 |        |                |       |        |
| **ArraySortDotnet** |   **1000** |       **119.1 μs** |    **NA** |   **1.00** |
|      SelectSort |   1000 |       418.8 μs |    NA |   3.52 |
|        HeapSort |   1000 |       196.3 μs |    NA |   1.65 |
|                 |        |                |       |        |
| **ArraySortDotnet** |  **10000** |       **464.2 μs** |    **NA** |   **1.00** |
|      SelectSort |  10000 |    28,193.3 μs |    NA |  60.74 |
|        HeapSort |  10000 |     1,371.2 μs |    NA |   2.95 |
|                 |        |                |       |        |
| **ArraySortDotnet** | **100000** |     **4,652.7 μs** |    **NA** |   **1.00** |
|      SelectSort | 100000 | 2,670,302.3 μs |    NA | 573.93 |
|        HeapSort | 100000 |    17,876.7 μs |    NA |   3.84 |
