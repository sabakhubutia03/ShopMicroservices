using FluentValidation;

namespace User.Application.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        
        RuleFor(n => n.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Username must not exceed 100 characters");
    }
}