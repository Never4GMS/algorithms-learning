``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.100
  [Host] : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Toolchain=InProcessEmitToolchain  InvocationCount=1  IterationCount=1  
IterationTime=500.0000 ms  LaunchCount=1  RunStrategy=ColdStart  
UnrollFactor=1  WarmupCount=0  

```
|                   Method |         input |               output |     Mean | Error | Test case | Test pass |                 Test result |
|------------------------- |-------------- |--------------------- |---------:|------:|---------- |---------- |---------------------------- |
| EndqueDequePriorityQueue | 10 operations | [10]:(...)3,2,1 [27] | 3.036 ms |    NA |         0 |      True | [10]: 10,9,8,7,6..5,4,3,2,1 |
