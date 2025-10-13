using Microsoft.EntityFrameworkCore;
using ApiWeb.Domain.Entities;

namespace ApiWeb.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}