using MediatR;
using Microsoft.Extensions.Logging;
using Mini_Blockchain.Domain.Entities;

public class CreateBlockHandler : IRequestHandler<CreateBlockCommand, BlockDto>
{
    private readonly IBlockRepository _repo;
    private readonly ILogger<CreateBlockHandler> _logger;

    public CreateBlockHandler(IBlockRepository repo, ILogger<CreateBlockHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<BlockDto> Handle(CreateBlockCommand request, CancellationToken ct)
    {
        _logger.LogInformation("Creating block");

        var block = new Block
        {
            Data = request.Data,
            Timestamp = DateTime.UtcNow
        };

        await _repo.AddAsync(block, ct);

        return new BlockDto
        {
            Data = block.Data,
            Timestamp = block.Timestamp
        };
    }
}