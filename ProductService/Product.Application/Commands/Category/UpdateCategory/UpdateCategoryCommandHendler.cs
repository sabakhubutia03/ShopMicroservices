using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHendler : IRequestHandler<UpdateCategoryCommand ,CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHendler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var updateCategory = await _categoryRepository.GetById(request.Id);
        if (updateCategory == null)
        {
            throw new ApiException(
                "Failed to update category",
                "NotFound",
                404,
                "Failed to update category",
                "Failed to update category" 
            );
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            updateCategory.Name = request.Name;
        } 
        await _categoryRepository.Update(updateCategory);
        
        return new CategoryResponseDto
        {
            Id = updateCategory.Id,
            Name = updateCategory.Name
        };
    }
}