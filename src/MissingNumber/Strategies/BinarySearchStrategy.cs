namespace MissingNumber.Strategies;

public sealed class BinarySearchStrategy : IMissingNumbersStrategy
{
  public int FindMissing(IReadOnlyList<int> nums)
  {
    var copy = nums.ToArray();
    Array.Sort(copy);

    int lo = 0, hi = copy.Length;
    while (lo < hi)
    {
      var mid = lo + ((hi - lo) >> 1);
      if (copy[mid] == mid)
      {
        lo = mid + 1;
      }
      else
      {
        hi = mid;
      }
    }
    return lo;
  }
}
