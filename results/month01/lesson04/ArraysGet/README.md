``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.100
  [Host] : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Toolchain=InProcessEmitToolchain  InvocationCount=1  IterationCount=1  
IterationTime=500.0000 ms  LaunchCount=1  RunStrategy=ColdStart  
UnrollFactor=1  WarmupCount=0  

```
|          Method |                input |               output |       Mean | Error | Ratio | Test case | Test pass |   Test result |
|---------------- |--------------------- |--------------------- |-----------:|------:|------:|---------- |---------- |-------------- |
| GetWrappedArray | [20]:(...)19,20 [56] | [10]:(...)17,19 [31] | 1,625.3 μs |    NA |  1.00 |         0 |     False | empty or null |
|  GetSingleArray | [20]:(...)19,20 [56] | [10]:(...)17,19 [31] |   650.8 μs |    NA |  0.40 |         0 |     False | empty or null |
|  GetVectorArray | [20]:(...)19,20 [56] | [10]:(...)17,19 [31] |   570.1 μs |    NA |  0.35 |         0 |     False | empty or null |
|  GetFactorArray | [20]:(...)19,20 [56] | [10]:(...)17,19 [31] |   576.0 μs |    NA |  0.35 |         0 |     False | empty or null |
|  GetMatrixArray | [20]:(...)19,20 [56] | [10]:(...)17,19 [31] | 1,107.1 μs |    NA |  0.68 |         0 |     False | empty or null |
