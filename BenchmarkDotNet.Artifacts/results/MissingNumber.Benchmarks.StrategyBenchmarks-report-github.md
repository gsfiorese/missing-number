```

BenchmarkDotNet v0.15.2, Linux Ubuntu 22.04.5 LTS (Jammy Jellyfish)
13th Gen Intel Core i9-13980HX, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2


```
| Method | N       | Mean        | Error      | StdDev     |
|------- |-------- |------------:|-----------:|-----------:|
| **Sum**    | **10000**   |    **18.75 μs** |   **0.375 μs** |   **0.616 μs** |
| Sum    | 10000   |    18.54 μs |   0.355 μs |   0.462 μs |
| Xor    | 10000   |    16.55 μs |   0.303 μs |   0.463 μs |
| Xor    | 10000   |    16.41 μs |   0.287 μs |   0.240 μs |
| Binary | 10000   |    33.81 μs |   0.674 μs |   1.180 μs |
| Binary | 10000   |    33.37 μs |   0.655 μs |   1.230 μs |
| **Sum**    | **1000000** | **1,916.14 μs** |  **37.712 μs** |  **67.033 μs** |
| Xor    | 1000000 | 1,723.41 μs |  34.112 μs |  64.902 μs |
| Binary | 1000000 | 6,145.99 μs | 144.304 μs | 425.483 μs |
