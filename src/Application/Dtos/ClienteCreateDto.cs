namespace ApiWeb.Application.Dtos;

public record ClienteCreateDto(
    string Nome, 
    string Email, 
    string Telefone
);