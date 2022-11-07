using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{Name} don't be empty")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} don't be greater than 50 characters");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} don't be empty");
        }
    }
}
