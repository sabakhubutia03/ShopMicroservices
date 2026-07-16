using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Category;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand , CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public  async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Entity.Category
        {
            Name = request.Name
        };
        
        var createdCategory = await _categoryRepository.Create(category);
        if (createdCategory == null)
        {
            throw new ApiException(
                "Failed to create category",
                "BadRequest",
                400,
                "Failed to create category",
                "Failed to create category"
            );
        }

        return new CategoryResponseDto
        {
            Id = createdCategory.Id,
            Name = request.Name
        };
    }
}