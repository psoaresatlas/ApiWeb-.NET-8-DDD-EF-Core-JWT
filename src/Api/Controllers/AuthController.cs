using Microsoft.AspNetCore.Mvc;
using ApiWeb.Application.Dtos;
using ApiWeb.Application.Interfaces;
using ApiWeb.Domain.Entities;

namespace ApiWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthController(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            return BadRequest("E-mail já cadastrado.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new Domain.Entities.User
        {
            Email = dto.Email,
            PasswordHash = passwordHash
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return Ok("Usuário registrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
            return Unauthorized("Credenciais inválidas.");

        bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!passwordValid)
            return Unauthorized("Credenciais inválidas.");

        var token = _tokenService.GenerateToken(user);
        return Ok(new AuthResponseDto(token));
    }
}
