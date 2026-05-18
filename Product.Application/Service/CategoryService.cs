using Product.Application.DTOs;
using Product.Application.Interface;

namespace Product.Application.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public Task<CategoryResponseDto> CreateCategory(CategoryCreateDto categoryCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponseDto> GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResponseDto>> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponseDto> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}