using MissingNumber.Core;

namespace MissingNumber.ConsoleApp;

public static class Program
{
  public static void Main(string[] args)
  {
    if (args.Length >= 2)
    {
      RunArgMode(args);
      return;
    }

    System.Console.WriteLine("Welcome to Missing Number Console!");
    System.Console.WriteLine("Pick your strategy: xor | binary | sum");
    System.Console.Write("Strategy: ");

    var key = (System.Console.ReadLine() ?? "").Trim();
    System.Console.Write("Numbers (space-separated): ");

    var line = System.Console.ReadLine() ?? string.Empty;

    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 0)
    {
      Error("No numbers provided.");
      return;
    }

    if (!TryParseAll(parts, out var nums))
    {
      Error("Invalid number list.");
      return;
    }

    Solve(key, nums);
  }

  private static void RunArgMode(string[] args)
  {
    var strategyKey = args[0];
    var numberArgs = args.Skip(1);

    if (!TryParseAll(numberArgs, out var nums))
    {
      System.Console.WriteLine("Usage: MissingNumber.Console <strategy> <numbers...>");
      System.Console.WriteLine("Example: MissingNumber.Console xor 3 0 1");
      return;
    }
  }

  private static bool TryParseAll(IEnumerable<string> items, out int[] result)
  {
    var list = new List<int>();
    foreach (var s in items)
    {
      if (!int.TryParse(s, out var v))
      {
        result = Array.Empty<int>();
        return false;
      }
      list.Add(v);
    }
    result = list.ToArray();
    return true;
  }

  private static void Solve(string strategyKey, int[] nums)
  {
    try
    {
      var service = Composition.Build(strategyKey);
      var missing = service.Find(nums);
      System.Console.WriteLine($"Missing number: {missing}");
    }
    catch (Exception ex)
    {
      Error(ex.Message);
    }
  }

  private static void Error(string msg)
  {
    var old = System.Console.ForegroundColor;
    System.Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine($"Error: {msg}");
    System.Console.ForegroundColor = old;
  }
}
