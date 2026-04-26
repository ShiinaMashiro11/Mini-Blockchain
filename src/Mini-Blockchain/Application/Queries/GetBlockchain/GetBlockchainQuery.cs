using MediatR;
using Mini_Blockchain.Application.DTOs;
namespace Mini_Blockchain.Application.Queries.GetBlockchain;

public class GetBlockchainQuery : IRequest<List<BlockDto>> { }