
namespace Product.Application.Interface;

public interface IProductRepository 
{ 
   Task<Domain.Entity.Product?> GetById(int id);
   Task<IEnumerable<Domain.Entity.Product?>> GetAll();
   Task<Domain.Entity.Product?> Create(Domain.Entity.Product product);
   Task<Domain.Entity.Product> Update(Domain.Entity.Product product);
   Task Delete(Domain.Entity.Product product) ;
}