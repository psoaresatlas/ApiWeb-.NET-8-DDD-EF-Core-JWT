using ApiWeb.Domain.Entities;

namespace ApiWeb.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<int> SaveChangesAsync();
}
