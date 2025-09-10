using FluentAssertions;
using MissingNumber.Core;
using Xunit;

namespace MissingNumber.Tests;

public class MissingNumberServiceTests
{
  [Theory]
  [InlineData(new[] { 3, 0, 1 }, 2)]
  [InlineData(new[] { 0 }, 1)]
  [InlineData(new[] { 1, 0 }, 2)]
  [InlineData(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
  [InlineData(new[] { 4, 3, 2, 1 }, 0)]
  public void Composition_DefaultXor_FindMissing(int[] nums, int expected)
  {
    var svc = Composition.Build("xor");
    svc.Find(nums).Should().Be(expected);
  }

  [Theory]
  [InlineData("sum")]
  [InlineData("xor")]
  [InlineData("binary")]
  public void AllStrategies_WorkOnInput(string key)
  {
    var svc = Composition.Build(key);
    svc.Find(new[] { 3, 0, 1 }).Should().Be(2);
  }
}
