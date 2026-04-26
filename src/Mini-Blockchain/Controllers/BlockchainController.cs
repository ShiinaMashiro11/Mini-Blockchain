using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Blockchain.Models;
using Mini_Blockchain.Services;
using Mini_Blockchain.Data;

namespace Mini_Blockchain.Controllers
{
    [ApiController]
    [Route("api/blockchain")]
    public class BlockchainController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BlockchainController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("hash")]
        public IActionResult GenerateHash([FromBody] string text)
        {
            return Ok(HashHelper.ComputeHash(text));
        }

        [HttpPost("block")]
        public async Task<IActionResult> AddBlock([FromBody] CreateBlockRequest request)
        {
            var dataHash = HashHelper.ComputeHash(request.Data);

            var lastBlock = await _db.Blocks
                .OrderByDescending(b => b.Id)
                .FirstOrDefaultAsync();

            var previousHash = lastBlock == null ? "GENESIS" : lastBlock.DataHash;

            var block = new Block
            {
                DataHash = dataHash,
                PreviousHash = previousHash,
                Timestamp = DateTime.UtcNow
            };

            _db.Blocks.Add(block);
            await _db.SaveChangesAsync();

            return Ok(block);
        }

        [HttpGet]
        public async Task<IActionResult> GetChain()
        {
            var chain = await _db.Blocks.OrderBy(b => b.Id).ToListAsync();
            return Ok(chain);
        }

        [HttpGet("validate")]
        public async Task<IActionResult> Validate()
        {
            var chain = await _db.Blocks.OrderBy(b => b.Id).ToListAsync();

            for (int i = 1; i < chain.Count; i++)
            {
                if (chain[i].PreviousHash != chain[i - 1].DataHash)
                    return BadRequest("Chain is broken!");
            }

            return Ok("Chain is valid");
        }
    }
}