using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Entity;
using Product.Domain.Exceptions;

namespace Product.Application.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryResponseDto> CreateCategory(CategoryCreateDto categoryCreateDto)
    {
        var category = new Category
        {
            Name = categoryCreateDto.Name
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
            Name = categoryCreateDto.Name
        };
    }

    public async Task<CategoryResponseDto> GetCategoryById(int id)
    {
        var category =  await _categoryRepository.GetById(id);
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

    public async Task<IEnumerable<CategoryResponseDto>> GetAllCategories()
    {
        var category = await _categoryRepository.GetAll();
        return category.Select(c => new CategoryResponseDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }

    public async Task<CategoryResponseDto> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var updateCategory = await _categoryRepository.GetById(id);
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

        if (!string.IsNullOrWhiteSpace(categoryUpdateDto.Name))
        {
            updateCategory.Name = categoryUpdateDto.Name;
        } 
        await _categoryRepository.Update(updateCategory);
        
        return new CategoryResponseDto
        {
            Id = updateCategory.Id,
            Name = updateCategory.Name
        };
    }

    public async Task DeleteCategory(int id)
    {
        var deleteCategory = await _categoryRepository.GetById(id);
        if (deleteCategory == null)
        {
            throw new ApiException(
                $"Not found category ID - {id}",
                "NotFound",
                404,
                "Not found category",
                "Not found category"
            );
        }
        await _categoryRepository.Delete(deleteCategory);
    }
}