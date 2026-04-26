using Mini_Blockchain.Domain.Entities;

public class FakeBlockRepository : IBlockRepository
{
    private static readonly List<Block> _storage = new();

    public Task AddAsync(Block block, CancellationToken ct)
    {
        _storage.Add(block);
        return Task.CompletedTask;
    }

    public Task<List<Block>> GetAllAsync(CancellationToken ct)
    {
        return Task.FromResult(_storage);
    }
}