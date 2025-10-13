using Microsoft.EntityFrameworkCore;
using ApiWeb.Application.Interfaces;
using ApiWeb.Domain.Entities;
using ApiWeb.Infrastructure.Data;

namespace ApiWeb.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _ctx;
    public ClienteRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(Cliente cliente) => await _ctx.Clientes.AddAsync(cliente);

    public async Task AddRangeAsync(IEnumerable<Cliente> clientes) => await _ctx.Clientes.AddRangeAsync(clientes);

    public async Task<List<Cliente>> GetAllAsync() => await _ctx.Clientes.ToListAsync();
    public async Task<Cliente?> GetByIdAsync(Guid id) => await _ctx.Clientes.FindAsync(id);
    public void Remove(Cliente cliente) => _ctx.Clientes.Remove(cliente);
    public void Update(Cliente cliente) => _ctx.Clientes.Update(cliente);
    public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
}
