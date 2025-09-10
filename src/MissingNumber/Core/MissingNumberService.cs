using MissingNumber.Strategies;
using MissingNumber.Validation;

namespace MissingNumber.Core;

public sealed class MissingNumberService
{
  private readonly IMissingNumbersStrategy _strategy;
  private readonly IInputValidator _validator;

  public MissingNumberService(IMissingNumbersStrategy strategy, IInputValidator validator)
  {
    _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    _validator = validator ?? throw new ArgumentNullException(nameof(validator));
  }

  public int Find(IReadOnlyList<int> nums)
  {
    var (ok, error) = _validator.Validate(nums);

    if (!ok)
    {
      throw new ArgumentException(error);
    }

    return _strategy.FindMissing(nums);
  }
}
