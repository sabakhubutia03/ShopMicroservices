using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Commands.Category.UpdateCategory;

public record UpdateCategoryCommand (int Id, string Name) 
    :IRequest<CategoryResponseDto>;