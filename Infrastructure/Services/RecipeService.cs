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

    public async Task<IEnumerable<RecipeResponseDTO>> GetRecipes()
    {
        var recipes = await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .ToListAsync();

        return recipes.Select(MapToResponseDTO);
    }

    public async Task<IEnumerable<RecipeListDTO>> GetRecipesList()
    {
        var recipes = await _context.Recipes
            .Select(r => new RecipeListDTO
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description
            })
            .ToListAsync();

        return recipes;
    }

    public async Task<RecipeResponseDTO?> GetRecipeById(Guid id)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

        return recipe == null ? null : MapToResponseDTO(recipe);
    }

    public async Task<RecipeResponseDTO> CreateRecipe(RecipeDTO recipeDto)
    {
        var recipe = new Recipe
        {
            Title = recipeDto.Title,
            Description = recipeDto.Description,
            Steps = recipeDto.Steps.Select(s => new StepRecipe
            {
                Title = s.Title,
                Description = s.Description,
                Parameters = s.Parameters.Select(p => new ParameterStep
                {
                    Name = p.Name,
                    Type = p.Type,
                    TypeData = p.TypeData,
                    Value = p.Value,
                }).ToList()
            }).ToList()
        };

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
        return MapToResponseDTO(recipe);
    }

    public async Task<bool> UpdateRecipe(Guid id, RecipeDTO recipeDto)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (recipe == null)
            return false;

        recipe.Title = recipeDto.Title;
        recipe.Description = recipeDto.Description;
        
        // Remove existing steps and parameters
        _context.ParameterSteps.RemoveRange(
            recipe.Steps.SelectMany(s => s.Parameters));
        _context.StepRecipes.RemoveRange(recipe.Steps);

        // Add new steps and parameters
        recipe.Steps = recipeDto.Steps.Select(s => new StepRecipe
        {
            Title = s.Title,
            Description = s.Description,
            Parameters = s.Parameters.Select(p => new ParameterStep
            {
                Name = p.Name,
                Type = p.Type,
                TypeData = p.TypeData,
                Value = p.Value,
            }).ToList()
        }).ToList();

        await _context.SaveChangesAsync();
        return true;
    }

    private static RecipeResponseDTO MapToResponseDTO(Recipe recipe)
    {
        return new RecipeResponseDTO
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Steps = recipe.Steps.Select(s => new StepRecipeResponseDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Parameters = s.Parameters.Select(p => new ParameterStepResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    TypeData = p.TypeData,
                    Value = p.Value
                }).ToList()
            }).ToList()
        };
    }
}