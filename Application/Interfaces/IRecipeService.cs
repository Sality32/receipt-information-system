using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;

namespace ReceiptInformationSystem.Application.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<RecipeResponseDTO>> GetRecipes();
    Task<IEnumerable<RecipeListDTO>> GetRecipesList();
    Task<RecipeResponseDTO?> GetRecipeById(Guid id);
    Task<RecipeResponseDTO> CreateRecipe(RecipeDTO recipeDto);
    Task<bool> UpdateRecipe(Guid id, RecipeDTO recipeDto);
}