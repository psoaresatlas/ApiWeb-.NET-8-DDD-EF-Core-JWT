using ApiWeb.Application.Dtos;

namespace ApiWeb.Application.Interfaces;

public interface IClienteService
{
    Task<List<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(Guid id);
    Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
    Task<List<ClienteDto>> CreateManyAsync(List<ClienteCreateDto> dtos);
    Task<bool> UpdateAsync(Guid id, ClienteUpdateDto dto);
    Task<bool> PatchAsync(Guid id, ClientePatchDto dto);
    Task<bool> DeleteAsync(Guid id);
}
