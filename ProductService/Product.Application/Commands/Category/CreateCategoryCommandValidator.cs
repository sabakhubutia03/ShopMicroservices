using FluentValidation;

namespace Product.Application.Commands.Category;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters");
    }
}