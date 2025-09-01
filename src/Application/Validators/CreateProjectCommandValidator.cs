using Application.Commands;
using FluentValidation;


namespace Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project title is required")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");
        }
    }
}
