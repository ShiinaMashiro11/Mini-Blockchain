using Microsoft.EntityFrameworkCore;
using Mini_Blockchain.Application.Interfaces;
using Mini_Blockchain.Domain.Entities;
using Mini_Blockchain.Infrastructure.Persistence;

namespace Mini_Blockchain.Infrastructure.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly ApplicationDbContext _context;

        public BlockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Block>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Blocks
                .OrderBy(b => b.Timestamp)
                .ToListAsync(ct);
        }

        public async Task AddAsync(Block block, CancellationToken ct)
        {
            await _context.Blocks.AddAsync(block, ct);
            await _context.SaveChangesAsync(ct);
        }
    }
}