using Mini_Blockchain.Domain.Entities;
namespace Mini_Blockchain.Application.Interfaces;

public interface IBlockRepository
{
    Task<List<Block>> GetAllAsync(CancellationToken ct);
    Task AddAsync(Block block, CancellationToken ct);
}