using Villsource.Result.Errors;
using Villsource.Result.Test.TestUtils;
using Villsource.Result.Test.TestUtils.Assertions;

namespace Villsource.Result.Test;

public class ValueResultTest: AutoFixBase
{
        
    [Fact]
    public void ValueResult_Should_BeOk()
    {
        var sut = new Result<string>("value");
        
        sut.ShouldOk();
        sut.ShouldHaveNoError();
        sut.ShouldHaveValue();
    }
     
    
    [Fact]
    public void FailResult_Should_NotBeOk()
    {
        var sut = new Result<string>(ErrorReasonConstants.PRIVILEGE);
        
        sut.ShouldFail();
        sut.ShouldHaveError();
        sut.ShouldHaveNoValue();
    }    
    
    [Fact]
    public void FailResultNoErr_Should_NotBeOk()
    {
        var sut = new Result<string>(error:null);
        
        sut.ShouldFail();
        sut.ShouldHaveNoError();
        sut.ShouldHaveNoValue();
    }

    
    [Theory]
    [InlineData(0)]
    [InlineData("string")]
    [InlineData(false)]
    public void GetTypeValueResult_Should_NotBeNull(object value)
    {
        var t = typeof(Result<>).MakeGenericType(value.GetType());
        var sut = (IResult)Activator.CreateInstance(t, value)!;
        sut.GetValueObject().Should().BeOfType(value.GetType());
    }
    
    
    [Fact]
    public void GetTypeResult_Should_NotBeNull()
    {
        Result<int> sut = new Result();
        sut.GetValueObject().Should().NotBeNull();
    }
}