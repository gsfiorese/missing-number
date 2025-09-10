namespace MissingNumber.Strategies;

public interface IInputValidator
{
  (bool ok, string? error) Validate(IReadOnlyList<int> nums);
}
