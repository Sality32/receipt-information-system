using Microsoft.AspNetCore.Mvc;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;

namespace ReceiptInformationSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParameterTypeController : ControllerBase
{
    private readonly IParameterTypeService _parameterTypeService;

    public ParameterTypeController(IParameterTypeService parameterTypeService)
    {
        _parameterTypeService = parameterTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _parameterTypeService.GetParameterTypes());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var parameterType = await _parameterTypeService.GetParameterTypeById(id);
        if (parameterType == null)
            return NotFound();

        return Ok(parameterType);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ParameterTypeDTO parameterTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var parameterType = await _parameterTypeService.CreateParameterType(parameterTypeDto);
        return CreatedAtAction(nameof(GetById), new { id = parameterType.Id }, parameterType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ParameterTypeDTO parameterTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _parameterTypeService.UpdateParameterType(id, parameterTypeDto);
        if (!updated)
            return NotFound();

        return NoContent();
    }
}