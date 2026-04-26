using MediatR;
using Mini_Blockchain.Application.DTOs;
namespace Mini_Blockchain.Application.Commands.CreateBlock;

public class CreateBlockCommand : IRequest<BlockDto>
{
    public string Data { get; set; } = string.Empty;
}