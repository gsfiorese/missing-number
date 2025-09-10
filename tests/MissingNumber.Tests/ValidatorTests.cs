using FluentAssertions;
using MissingNumber.Validation;
using Xunit;

namespace MissingNumber.Tests;

public class ValidatorTests
{
    private readonly InputValidator _validator = new();

    [Fact]
    public void Null_Fails()
    {
        var (ok, error) = _validator.Validate(null!);
        ok.Should().BeFalse();
        error.Should().Contain("null");
    }

    [Fact]
    public void Empty_Fails()
    {
        var (ok, error) = _validator.Validate(Array.Empty<int>());
        ok.Should().BeFalse();
        error.Should().Contain("empty");
    }

    [Fact]
    public void OutOfRange_Fails()
    {
        var (ok, error) = _validator.Validate(new[] { 0, 4, 1 });
        ok.Should().BeFalse();
        error.Should().Contain("out of range");
    }

    [Fact]
    public void Duplicate_Fails()
    {
        var (ok, error) = _validator.Validate(new[] { 0, 1, 1 });
        ok.Should().BeFalse();
        error.Should().Contain("duplicate");
    }

    [Fact]
    public void Valid_Passes()
    {
        var (ok, error) = _validator.Validate(new[] { 3, 0, 1 });
        ok.Should().BeTrue();
        error.Should().BeNull();
    }
}
