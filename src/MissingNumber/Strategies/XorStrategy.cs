namespace MissingNumber.Strategies;

public sealed class XorStrategy : IMissingNumbersStrategy
{
  public int FindMissing(IReadOnlyList<int> nums)
  {
    var n = nums.Count;
    var x = n;

    for (var i = 0; i < n; i++)
    {
      x ^= i ^ nums[i];
    }
    return x;
  }
}
