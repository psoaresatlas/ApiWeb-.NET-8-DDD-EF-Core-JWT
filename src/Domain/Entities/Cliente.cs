namespace ApiWeb.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}