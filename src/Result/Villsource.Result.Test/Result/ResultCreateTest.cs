using Villsource.Result.Errors;
using Villsource.Result.Test.TestUtils;
using Villsource.Result.Test.TestUtils.Assertions;

namespace Villsource.Result.Test;

public class ResultCreateTest : AutoFixBase
{
    [Fact]
    public void CreateOkResult_Should_BeOk()
    {
        var sut = Result.Ok();
        sut.ShouldOk();
        sut.ShouldHaveNoError();
        sut.ShouldHaveNoValue();
    }
    
    [Fact]
    public void CreateOkValueResult_Should_BeOk()
    {
        var sut = Result.Ok(11);
        sut.ShouldOk();
        sut.ShouldHaveNoError();
        sut.ShouldHaveValue();
    }
    
    [Fact]
    public void CreateFailResult_Should_NotBeOk()
    {
        var sut = Result.Fail();
        sut.ShouldFail();
        sut.ShouldHaveNoError();
        sut.ShouldHaveNoValue();
    }
    
    [Fact]
    public void CreateFailResultWithReason_Should_NotBeOk()
    {
        var sut = Result.Fail(ErrorReasonConstants.PRIVILEGE);
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }
    
    
    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(10)]
    public void CreateFailResultWithReasons_Should_NotBeOk(int round)
    {
        var errors = Enumerable.Range(0, round).Select(i => ErrorReasonConstants.PRIVILEGE).ToArray();
        var sut = Result.Fail(errors);
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }
    
    [Fact]
    public void CreateFailResultWithStringReasons_Should_NotBeOk()
    {
        var sut = Result.Fail("Test Error#1", "Test Error#2");
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }

    [Fact]
    public void CreateInvalidResults_Should_NotBeOk()
    {
        var sut = Result.Invalid();
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }

    [Fact]
    public void CreateNotFoundResults_Should_NotBeOk()
    {
        var sut = Result.NotFound();
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }
    
    [Fact]
    public void CreateNoPrivilegeResults_Should_NotBeOk()
    {
        var sut = Result.NoPrivilege();
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }
}