using MediatR;
using Mini_Blockchain.Application.DTOs;
using Mini_Blockchain.Application.Interfaces;
using Mini_Blockchain.Domain.Entities;
namespace Mini_Blockchain.Application.Queries.ValidateChain;

public class ValidateChainHandler : IRequestHandler<ValidateChainQuery, bool>
{
    private readonly IBlockRepository _repo;

    public ValidateChainHandler(IBlockRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(ValidateChainQuery request, CancellationToken ct)
    {
        var blocks = await _repo.GetAllAsync(ct);
        return blocks.Count > 0;
    }
}