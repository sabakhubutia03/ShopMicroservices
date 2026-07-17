using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Queries.GetCategoryById;

public class GetCategoryByIdQueryHnadler : IRequestHandler<GetCategoryByIdQuery , CategoryResponseDto>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByIdQueryHnadler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category =  await _repository.GetById(request.Id);
        if (category == null)
        {
            throw new ApiException(
                "Category not found",
                "NotFound",
                404,
                "Category not found",
                "Category not found"
            );
        }
        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}