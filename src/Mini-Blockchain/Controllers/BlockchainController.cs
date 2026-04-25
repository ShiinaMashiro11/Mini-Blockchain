using Microsoft.AspNetCore.Mvc;
using Mini_Blockchain.Models;
using Mini_Blockchain.Services;
using Mini_Blockchain.Data;

namespace Mini_Blockchain.Controllers
{
    [ApiController]
    [Route("api/blockchain")]
    public class BlockchainController : ControllerBase
    {
        [HttpPost("hash")]
        public IActionResult GenerateHash([FromBody] string text)
        {
            return Ok(HashHelper.ComputeHash(text));
        }

        [HttpPost("block")]
        public IActionResult AddBlock([FromBody] CreateBlockRequest request)
        {
            var dataHash = HashHelper.ComputeHash(request.Data);

            var previousHash = BlockchainDb.Chain.Count == 0
                ? "GENESIS"
                : BlockchainDb.Chain.Last().DataHash;

            var block = new Block
            {
                Id = BlockchainDb.Chain.Count + 1,
                DataHash = dataHash,
                PreviousHash = previousHash,
                Timestamp = DateTime.UtcNow
            };

            BlockchainDb.Chain.Add(block);

            return Ok(block);
        }

        [HttpGet("validate")]
        public IActionResult Validate()
        {
            for (int i = 1; i < BlockchainDb.Chain.Count; i++)
            {
                var current = BlockchainDb.Chain[i];
                var previous = BlockchainDb.Chain[i - 1];

                if (current.PreviousHash != previous.DataHash)
                    return BadRequest("Chain is broken!");
            }

            return Ok("Chain is valid");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(BlockchainDb.Chain);
        }
    }
}