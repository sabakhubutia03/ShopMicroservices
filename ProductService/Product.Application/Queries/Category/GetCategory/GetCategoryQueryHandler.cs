using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;

namespace Product.Application.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryResponseDto>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public  async Task<List<CategoryResponseDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetAll();
        return category.Select(c => new CategoryResponseDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}