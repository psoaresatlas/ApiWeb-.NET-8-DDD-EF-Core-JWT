using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiWeb.Application.Dtos;
using ApiWeb.Application.Interfaces;

namespace ApiWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();
        if (clientes == null || !clientes.Any())
            return NotFound("Nenhum cliente encontrado.");
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null)
            return NotFound("Cliente não encontrado.");
        return Ok(cliente);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClienteCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Dados inválidos.");

        var created = await _clienteService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [Authorize]
    [HttpPost("batch")]
    public async Task<IActionResult> CreateBatch([FromBody] List<ClienteCreateDto> dtos)
    {
        if (dtos == null || !dtos.Any())
            return BadRequest("A lista de clientes está vazia.");

        var created = await _clienteService.CreateManyAsync(dtos);
        return Ok(created);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClienteUpdateDto dto)
    {
        if (dto == null)
            return BadRequest("Dados inválidos.");

        var result = await _clienteService.UpdateAsync(id, dto);
        if (!result)
            return NotFound("Cliente não encontrado.");
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _clienteService.DeleteAsync(id);
        if (!result)
            return NotFound("Cliente não encontrado.");
        return NoContent();
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] ClientePatchDto dto)
    {
        if (dto == null)
            return BadRequest("Dados inválidos.");

        var result = await _clienteService.PatchAsync(id, dto);
        if (!result)
            return NotFound("Cliente não encontrado.");
        
        return NoContent(); 
    }

}
