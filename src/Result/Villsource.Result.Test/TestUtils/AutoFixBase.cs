using AutoFixture.AutoMoq;

namespace Villsource.Result.Test.TestUtils;

public abstract class AutoFixBase
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}