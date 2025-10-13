namespace ApiWeb.Application.Dtos;

public record ClienteDto(
    Guid Id, 
    string Nome, 
    string Email, 
    string Telefone, 
    DateTime CreatedAt
);