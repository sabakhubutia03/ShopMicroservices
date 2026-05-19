using Microsoft.EntityFrameworkCore;
using Product.Application.Interface;
using Product.Domain.Entity;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{ 
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Category?> GetById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category?>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> Create(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> Update(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task Delete(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}