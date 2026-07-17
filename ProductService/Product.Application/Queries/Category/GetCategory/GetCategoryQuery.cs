using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Queries.GetCategory;

public record GetCategoryQuery : IRequest<List<CategoryResponseDto>>;