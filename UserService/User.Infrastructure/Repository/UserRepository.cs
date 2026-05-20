using Microsoft.EntityFrameworkCore;
using User.Application.Interface;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Domain.Entity.User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
        
    }

    public async Task<Domain.Entity.User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<Domain.Entity.User?> Create(Domain.Entity.User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task Delete(Domain.Entity.User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
    }

    public async Task<Domain.Entity.User?> Update(Domain.Entity.User user)
    {
         _context.Users.Update(user);
         await _context.SaveChangesAsync();
         return user;
    }
}