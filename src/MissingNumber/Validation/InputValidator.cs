using MissingNumber.Strategies;

namespace MissingNumber.Validation;

public sealed class InputValidator : IInputValidator
{
  public (bool ok, string? error) Validate(IReadOnlyList<int> nums)
  {
    if (nums is null)
    {
      return (false, "num is null");
    }

    if (nums.Count == 0)
    {
      return (false, "nums is empty; expected lenght >= 1");
    }

    var n = nums.Count;
    var seen = new HashSet<int>(capacity: n);
    for (var i = 0; i < n; i++)
    {
      var v = nums[i];
      if ((uint)v > (uint)n)
      {
        return (false, $"value out of range at index {i}:{v} (allowed 0..{n})");
      }
      if (!seen.Add(v))
      {
        return (false, $"duplicate value: {v}");
      }
    }
    return (true, null);
  }
}
