using Villsource.Result.Errors;
using Villsource.Result.Test.TestUtils;
using Villsource.Result.Test.TestUtils.Assertions;

namespace Villsource.Result.Test;

public class ResultTest : AutoFixBase
{
    
    [Fact]
    public void DefaultResult_Should_BeOk()
    {
        var sut = new Result();
        
        sut.ShouldOk();
        sut.ShouldHaveNoValue();
        sut.ShouldHaveNoError();
    }
    
    
    [Fact]
    public void ValueResult_Should_BeOk()
    {
        var sut = new Result("value");
        
        sut.ShouldOk();
        sut.ShouldHaveNoError();
        sut.ShouldHaveValue();
    }
     
    
    [Fact]
    public void FailResult_Should_NotBeOk()
    {
        var sut = new Result(ErrorReasonConstants.PRIVILEGE);
        
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }

    
    [Theory]
    [InlineData(0)]
    [InlineData("string")]
    [InlineData(false)]
    public void GetTypeResult_Should_NotBeNull(object value)
    {
        var sut = new Result(value);
        sut.GetValueObject().Should().BeOfType(value.GetType());
    }
    
    
    [Fact]
    public void GetTypeResult_Should_BeNull()
    {
        var sut = new Result();
        sut.GetValueObject().Should().BeNull();
    }
}