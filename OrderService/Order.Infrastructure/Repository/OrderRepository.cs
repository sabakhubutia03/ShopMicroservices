using Microsoft.EntityFrameworkCore;
using Order.Application.Interface;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{ 
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Domain.Entities.Order?> GetById(int id)
    {
        var order = await _appDbContext.Orders.FindAsync(id);
        return order;
    }

    public async Task<IEnumerable<Domain.Entities.Order>> GetAll()
    {
        return await _appDbContext.Orders.ToListAsync();
    }

    public async Task<Domain.Entities.Order> Create(Domain.Entities.Order order)
    {
        await _appDbContext.Orders.AddAsync(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Domain.Entities.Order> Update(Domain.Entities.Order order)
    {
        _appDbContext.Orders.Update(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }

    public async Task Delete(Domain.Entities.Order order)
    {
        _appDbContext.Orders.Remove(order);
        await _appDbContext.SaveChangesAsync();
    }
}