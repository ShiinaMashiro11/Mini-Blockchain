using FluentValidation;

namespace Mini_Blockchain.Application.Commands.CreateBlock;

public class CreateBlockValidator : AbstractValidator<CreateBlockCommand>
{
    public CreateBlockValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty()
            .MaximumLength(500);
    }
}