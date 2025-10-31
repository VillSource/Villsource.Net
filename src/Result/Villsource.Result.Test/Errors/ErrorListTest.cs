using System.Collections;
using Villsource.Result.Test.TestUtils;

namespace Villsource.Result.Errors.Test;

public class ErrorListTest : AutoFixBase
{
    public static ErrorList GetSut() => [ErrorReasonConstants.PRIVILEGE, ErrorReasonConstants.NOTFOUND];
    
    [Fact]
    public void ErrorList_Should_BeIErrorArray()
    {
        IEnumerable sut = GetSut();
        IEnumerable expected = new List<IError> {ErrorReasonConstants.PRIVILEGE, ErrorReasonConstants.NOTFOUND};

        sut.Should().BeEquivalentTo(expected);
    }
}