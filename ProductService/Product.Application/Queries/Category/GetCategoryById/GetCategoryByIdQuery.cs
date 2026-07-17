using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Queries.GetCategoryById;

public record GetCategoryByIdQuery (int Id) : IRequest<CategoryResponseDto>;