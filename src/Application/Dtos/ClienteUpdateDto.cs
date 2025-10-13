namespace ApiWeb.Application.Dtos;

public record ClienteUpdateDto(
    string Nome, 
    string Email, 
    string Telefone
);