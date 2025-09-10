using System.Reflection;
using MissingNumber.Strategies;

namespace MissingNumber.Core;

public static class Composition
{
  private static readonly Dictionary<string, IMissingNumbersStrategy> Strategies =
  new(StringComparer.OrdinalIgnoreCase)
  {
    ["sum"] = new SumStrategy(),
    ["xor"] = new XorStrategy(),
    ["binary"] = new BinarySearchStrategy()
  };

  public static MissingNumberService Build(string strategyKey = "xor")
  {
    if (!Strategies.TryGetValue(strategyKey, out var s))
    {
      throw new ArgumentException($"Unknown strategy '{strategyKey}'. Valid: {string.Join(", ", Strategies.Keys)}");
    }

    return new MissingNumberService(s, new Validation.InputValidator());
  }
}
