namespace User.Application.Interface;

public interface IUserRepository
{
    Task<Domain.Entity.User?>GetById(int id);
    Task<Domain.Entity.User?>GetByEmail(string email);
    Task<Domain.Entity.User?> Create (Domain.Entity.User user);
    Task Delete(Domain.Entity.User user);
    Task<Domain.Entity.User?> Update(Domain.Entity.User user);

}