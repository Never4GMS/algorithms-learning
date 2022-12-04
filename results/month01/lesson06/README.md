``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.100
  [Host] : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Toolchain=InProcessEmitToolchain  InvocationCount=1  IterationCount=1  
IterationTime=500.0000 ms  LaunchCount=1  RunStrategy=ColdStart  
UnrollFactor=1  WarmupCount=0  

```
|              Method |   Size |            Mean | Error |    Ratio |
|-------------------- |------- |----------------:|------:|---------:|
|     **ArraySortDotnet** |    **100** |        **155.7 μs** |    **NA** |     **1.00** |
|          BubbleSort |    100 |        725.9 μs |    NA |     4.66 |
|       InsertionSort |    100 |        452.5 μs |    NA |     2.91 |
|  InsertionShiftSort |    100 |        457.9 μs |    NA |     2.94 |
| InsertionBinarySort |    100 |        676.1 μs |    NA |     4.34 |
|           ShellSort |    100 |        137.7 μs |    NA |     0.88 |
|                     |        |                 |       |          |
|     **ArraySortDotnet** |   **1000** |        **129.0 μs** |    **NA** |     **1.00** |
|          BubbleSort |   1000 |      2,614.0 μs |    NA |    20.26 |
|       InsertionSort |   1000 |        970.1 μs |    NA |     7.52 |
|  InsertionShiftSort |   1000 |        232.9 μs |    NA |     1.81 |
| InsertionBinarySort |   1000 |        306.2 μs |    NA |     2.37 |
|           ShellSort |   1000 |      2,621.6 μs |    NA |    20.32 |
|                     |        |                 |       |          |
|     **ArraySortDotnet** |  **10000** |        **475.1 μs** |    **NA** |     **1.00** |
|          BubbleSort |  10000 |    256,335.3 μs |    NA |   539.54 |
|       InsertionSort |  10000 |     41,558.6 μs |    NA |    87.47 |
|  InsertionShiftSort |  10000 |     13,753.8 μs |    NA |    28.95 |
| InsertionBinarySort |  10000 |     15,049.7 μs |    NA |    31.68 |
|           ShellSort |  10000 |    176,247.8 μs |    NA |   370.97 |
|                     |        |                 |       |          |
|     **ArraySortDotnet** | **100000** |      **4,677.7 μs** |    **NA** |     **1.00** |
|          BubbleSort | 100000 | 17,415,489.9 μs |    NA | 3,723.09 |
|       InsertionSort | 100000 |  3,182,985.2 μs |    NA |   680.46 |
|  InsertionShiftSort | 100000 |  1,323,926.5 μs |    NA |   283.03 |
| InsertionBinarySort | 100000 |  1,358,168.0 μs |    NA |   290.35 |
|           ShellSort | 100000 | 17,471,498.3 μs |    NA | 3,735.06 |
