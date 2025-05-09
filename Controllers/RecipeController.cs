using Microsoft.AspNetCore.Mvc;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;

namespace ReceiptInformationSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _recipeService.GetRecipes());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _recipeService.GetRecipeById(id));

    [HttpGet("list")]
    public async Task<IActionResult> GetList() => 
        Ok(await _recipeService.GetRecipesList());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RecipeDTO recipeDto) {
        var result = await _recipeService.CreateRecipe(recipeDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
       

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RecipeDTO recipeDto)
    {
        var updated = await _recipeService.UpdateRecipe(id, recipeDto);
        if (!updated)
            return NotFound();
            
        return NoContent();
    }
}