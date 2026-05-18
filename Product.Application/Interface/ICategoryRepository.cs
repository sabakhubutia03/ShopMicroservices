using Product.Domain.Entity;

namespace Product.Application.Interface;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category?>> GetAll();
    Task<Category?>Create(Category category);
    Task<Category?>Update(Category category);
    Task Delete(Category category);
}