using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Mini_Blockchain.Application.Commands.CreateBlock;
using Mini_Blockchain.Application.Interfaces;

public class CreateBlockTests
{
    [Fact]
    public async Task Should_Create_Block()
    {
        var repo = new Mock<IBlockRepository>();

        var handler = new CreateBlockHandler(repo.Object, Mock.Of<ILogger<CreateBlockHandler>>());

        var result = await handler.Handle(
            new CreateBlockCommand { Data = "test" },
            CancellationToken.None);

        Assert.NotNull(result);
    }
}