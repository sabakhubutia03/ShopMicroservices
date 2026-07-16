using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Commands.Category;

public record CreateCategoryCommand(string Name) : IRequest<CategoryResponseDto>;