using MediatR;

namespace Product.Application.Commands.Category.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest<Unit>;