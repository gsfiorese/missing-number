# MissingNumber (Console + SOLID Core)

Find the single missing number in a `0..n` sequence given `n` distinct values.  
Projects:
- `src/MissingNumber/` – SOLID core (strategies, validator, service)
- `apps/MissingNumber.Console/` – console entry point
- `tests/MissingNumber.Tests/` – xUnit tests
- `bench/MissingNumber.Benchmarks/` – BenchmarkDotNet

## Prereqs
- .NET SDK 8.0+

## Build - Run - Tests - Benchmarks
```bash
dotnet build
dotnet run --project apps/MissingNumber.Console -- xor 3 0 1
dotnet run --project apps/MissingNumber.Console (interactive mode)
dotnet test
dotnet run -c Release --project bench/MissingNumber.Benchmarks
