using Product.Application.DTOs;

namespace Product.Application.Interface;

public interface ICategoryService
{
    Task<CategoryResponseDto> CreateCategory(CategoryCreateDto categoryCreateDto);
    Task<CategoryResponseDto> GetCategoryById(int id);
    Task<IEnumerable<CategoryResponseDto>> GetAllCategories();
    Task<CategoryResponseDto> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
    Task DeleteCategory(int id);
}