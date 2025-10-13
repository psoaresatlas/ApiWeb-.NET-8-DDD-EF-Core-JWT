using ApiWeb.Domain.Entities;

namespace ApiWeb.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
