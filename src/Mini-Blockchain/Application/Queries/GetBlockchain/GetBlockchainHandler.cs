using MediatR;
using Mini_Blockchain.Application.DTOs;
using Mini_Blockchain.Application.Interfaces;
using Mini_Blockchain.Domain.Entities;
namespace Mini_Blockchain.Application.Queries.GetBlockchain;

public class GetBlockchainHandler : IRequestHandler<GetBlockchainQuery, List<BlockDto>>
{
    private readonly IBlockRepository _repo;

    public GetBlockchainHandler(IBlockRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<BlockDto>> Handle(GetBlockchainQuery request, CancellationToken ct)
    {
        var blocks = await _repo.GetAllAsync(ct);

        return blocks.Select(x => new BlockDto
        {
            Data = x.Data,
            Timestamp = x.Timestamp
        }).ToList();
    }
}