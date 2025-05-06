using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;

namespace ReceiptInformationSystem.Application.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetRecipes();
    Task<Recipe?> GetRecipeById(Guid id);
    Task<Recipe> CreateRecipe(RecipeDTO recipeDto);
    Task<bool> UpdateRecipe(Guid id, RecipeDTO recipeDto);
}