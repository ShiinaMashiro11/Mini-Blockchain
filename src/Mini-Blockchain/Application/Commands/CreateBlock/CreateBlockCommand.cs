using MediatR;

public class CreateBlockCommand : IRequest<BlockDto>
{
    public string Data { get; set; }
}