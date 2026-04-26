using Mini_Blockchain.Domain.Entities;

public interface IBlockRepository
{
    Task<List<Block>> GetAllAsync(CancellationToken ct);
    Task AddAsync(Block block, CancellationToken ct);
}