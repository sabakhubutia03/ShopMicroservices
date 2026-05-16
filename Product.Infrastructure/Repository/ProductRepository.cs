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
    public Task<Domain.Entity.Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entity.Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entity.Product> Create(Domain.Entity.Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entity.Product> Update(Domain.Entity.Product product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Domain.Entity.Product product)
    {
        throw new NotImplementedException();
    }
}