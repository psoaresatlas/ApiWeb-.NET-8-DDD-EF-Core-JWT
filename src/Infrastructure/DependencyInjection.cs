using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiWeb.Application.Interfaces;
using ApiWeb.Infrastructure.Data;
using ApiWeb.Infrastructure.Repositories;
using ApiWeb.Infrastructure.Services;

namespace ApiWeb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IClienteRepository, ClienteRepository>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<ITokenService, TokenService>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}