using MediatR;
using Mini_Blockchain.Application.DTOs;
namespace Mini_Blockchain.Application.Queries.ValidateChain;

public class ValidateChainQuery : IRequest<bool> { }