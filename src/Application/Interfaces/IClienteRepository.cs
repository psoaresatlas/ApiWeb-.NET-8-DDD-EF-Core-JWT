using ApiWeb.Domain.Entities;

namespace ApiWeb.Application.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(Guid id);
    Task AddAsync(Cliente cliente);
    Task AddRangeAsync(IEnumerable<Cliente> clientes);
    void Update(Cliente cliente);
    void Remove(Cliente cliente);
    Task<int> SaveChangesAsync();
}