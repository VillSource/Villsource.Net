using FluentAssertions.Primitives;

namespace Villsource.Result.Test.TestUtils.Assertions;

public static class ResultAssertionExtension
{
    public static void ShouldOk(this IResult result) => result.IsOk().Should().BeTrue();
    public static void ShouldFail(this IResult result) => result.IsFail().Should().BeTrue();
    public static void ShouldHaveError(this IResult result) => result.GetError().Should().NotBeNull();
    public static void ShouldHaveNoError(this IResult result) => result.GetError().Should().BeNull();
    public static void ShouldHaveValue(this IResult result) => result.HasValue().Should().BeTrue();
    public static void ShouldHaveNoValue(this IResult result) => result.HasValue().Should().BeFalse();
}