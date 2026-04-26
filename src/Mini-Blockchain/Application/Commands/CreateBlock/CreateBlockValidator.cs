using FluentValidation;

public class CreateBlockValidator : AbstractValidator<CreateBlockCommand>
{
    public CreateBlockValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty()
            .MaximumLength(500);
    }
}