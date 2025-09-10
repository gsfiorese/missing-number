using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MissingNumber.Strategies;

namespace MissingNumber.Benchmarks;

public class StrategyBenchmarks
{
  [Params(10_000, 100_00, 1_000_000)]
  public int N;

  private int[] _data = default;
  private int _missingIndex;

  private readonly SumStrategy _sum = new();
  private readonly XorStrategy _xor = new();
  private readonly BinarySearchStrategy _bin = new();

  [GlobalSetup]
  public void Setup()
  {
    _missingIndex = N / 2;
    _data = Enumerable.Range(0, N).Where(i => i != _missingIndex).ToArray();
  }

  [Benchmark] public int Sum() => _sum.FindMissing(_data);
  [Benchmark] public int Xor() => _xor.FindMissing(_data);
  [Benchmark] public int Binary() => _bin.FindMissing(_data);

  public static void Main(string[] args) =>
  BenchmarkRunner.Run<StrategyBenchmarks>();
}
