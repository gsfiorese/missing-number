namespace MissingNumber.Strategies;

public sealed class SumStrategy : IMissingNumbersStrategy
{
  public int FindMissing(IReadOnlyList<int> nums)
  {
    var n = nums.Count;
    var expected = n * (n + 1) / 2;
    var actual = 0;

    for (var i = 0; i < n; i++)
    {
      actual += nums[i];
    }
    return expected - actual;
  }
}
