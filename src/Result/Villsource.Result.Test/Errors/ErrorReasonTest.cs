using Villsource.Result.Test.TestUtils;

namespace Villsource.Result.Errors.Test;

public class ErrorReasonTest : AutoFixBase
{
    [Fact]
    public void ErrorReason_Should_BeString()
    {
        var errorReason = "REASON";
        var sut = new ErrorReason(errorReason);
        
        sut.ToString().Should().BeEquivalentTo(errorReason);
    }
}