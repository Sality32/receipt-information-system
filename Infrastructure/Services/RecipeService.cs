using Microsoft.EntityFrameworkCore;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;
using ReceiptInformationSystem.Infrastructure.Data;

namespace ReceiptInformationSystem.Infrastructure.Services;

public class RecipeService : IRecipeService 
{
    private readonly AppDbContext _context;

    public RecipeService(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<Recipe>> GetRecipes() => 
        await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .ToListAsync();

    public async Task<Recipe?> GetRecipeById(Guid id) =>
        await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<Recipe> CreateRecipe(RecipeDTO recipeDto)
    {
        var recipe = new Recipe
        {
            Description = recipeDto.Description,
            Steps = recipeDto.Steps.Select(s => new StepRecipe
            {
                Description = s.Description,
                Parameters = s.Parameters.Select(p => new ParameterStep
                {
                    Name = p.Name,
                    Value = p.Value,
                }).ToList()
            }).ToList()
        };

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }

    public async Task<bool> UpdateRecipe(Guid id, RecipeDTO recipeDto)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (recipe == null)
            return false;

        recipe.Description = recipeDto.Description;
        
        // Remove existing steps and parameters
        _context.ParameterSteps.RemoveRange(
            recipe.Steps.SelectMany(s => s.Parameters));
        _context.StepRecipes.RemoveRange(recipe.Steps);

        // Add new steps and parameters
        recipe.Steps = recipeDto.Steps.Select(s => new StepRecipe
        {
            Description = s.Description,
            Parameters = s.Parameters.Select(p => new ParameterStep
            {
                Name = p.Name,
                Value = p.Value,
            }).ToList()
        }).ToList();

        await _context.SaveChangesAsync();
        return true;
    }
}