
using Business.Helpers;

namespace ContactConsole.MainApp.Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void Generate_ShouldReturnStringOfTypeGuid()
    {

        //act
        string id = IdGenerator.GenerateId();

        //assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
