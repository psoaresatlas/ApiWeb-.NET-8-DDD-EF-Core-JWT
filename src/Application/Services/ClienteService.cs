using ApiWeb.Application.Dtos;
using ApiWeb.Application.Interfaces;
using ApiWeb.Domain.Entities;

namespace ApiWeb.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
    {
        var cliente = new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        };

        await _repository.AddAsync(cliente);
        await _repository.SaveChangesAsync();

        return new ClienteDto(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.CreatedAt);
    }

    public async Task<List<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return clientes
            .Select(c => new ClienteDto(c.Id, c.Nome, c.Email, c.Telefone, c.CreatedAt))
            .ToList();
    }

    public async Task<ClienteDto?> GetByIdAsync(Guid id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return null;

        return new ClienteDto(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.CreatedAt);
    }

    public async Task<bool> UpdateAsync(Guid id, ClienteUpdateDto dto)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return false;

        cliente.Nome = dto.Nome;
        cliente.Email = dto.Email;
        cliente.Telefone = dto.Telefone;

        _repository.Update(cliente);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return false;

        _repository.Remove(cliente);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<List<ClienteDto>> CreateManyAsync(List<ClienteCreateDto> dtos)
    {
        if (dtos == null || !dtos.Any())
            return new List<ClienteDto>();

        var clientes = dtos.Select(dto => new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        }).ToList();

        await _repository.AddRangeAsync(clientes);

        await _repository.SaveChangesAsync();

        return clientes
            .Select(c => new ClienteDto(c.Id, c.Nome, c.Email, c.Telefone, c.CreatedAt))
            .ToList();
    }


    public async Task<bool> PatchAsync(Guid id, ClientePatchDto dto)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return false;

        if (dto.Nome != null)
            cliente.Nome = dto.Nome;
        
        if (dto.Email != null)
            cliente.Email = dto.Email;
        
        if (dto.Telefone != null)
            cliente.Telefone = dto.Telefone;

        _repository.Update(cliente);
        await _repository.SaveChangesAsync();
        return true;
    }
}
