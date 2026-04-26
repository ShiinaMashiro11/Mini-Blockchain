using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mini_Blockchain.Application.Commands.CreateBlock;
using Mini_Blockchain.Application.Queries.GetBlockchain;
using Mini_Blockchain.Application.Queries.ValidateChain;

[ApiController]
[Route("api/blockchain")]
public class BlockchainController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlockchainController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlockCommand command, CancellationToken ct)
    {
        return Ok(await _mediator.Send(command, ct));
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        return Ok(await _mediator.Send(new GetBlockchainQuery(), ct));
    }

    [HttpGet("validate")]
    public async Task<IActionResult> Validate(CancellationToken ct)
    {
        return Ok(await _mediator.Send(new ValidateChainQuery(), ct));
    }
}