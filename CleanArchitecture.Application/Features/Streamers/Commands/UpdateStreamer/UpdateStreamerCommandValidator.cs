using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator:AbstractValidator<UpdateStreamerCommand>    
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("{Name} don't be nullable!");
            RuleFor(x=>x.Url)
                .NotEmpty().WithMessage("{Url} don't be nullable!");
        }
    }
}
