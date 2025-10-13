namespace ApiWeb.Application.Dtos;

public record ClientePatchDto(
    string? Nome,
    string? Email,
    string? Telefone
);