namespace Order.Application.Interface;

public interface IOrderRepository
{
    Task<Order.Domain.Entities.Order> GetById(int id);
    Task<IEnumerable<Order.Domain.Entities.Order>> GetAll();
    Task<Domain.Entities.Order> Create(Domain.Entities.Order order);
    Task<Domain.Entities.Order>Update (Domain.Entities.Order order);
    Task Delete(Domain.Entities.Order order);
}