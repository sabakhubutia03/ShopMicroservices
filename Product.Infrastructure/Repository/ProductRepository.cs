using Microsoft.EntityFrameworkCore;
using Product.Application.Interface;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{ 
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Domain.Entity.Product> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Domain.Entity.Product?>> GetAll()
    {
        return await _context.Products.ToListAsync(); 
    }

    public async Task<Domain.Entity.Product?> Create(Domain.Entity.Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == product.Id);
    }

    public async Task<Domain.Entity.Product> Update(Domain.Entity.Product product)
    { 
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task Delete(Domain.Entity.Product product)
    {
         _context.Products.Remove(product);
         await _context.SaveChangesAsync();
    }
}