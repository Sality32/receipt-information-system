namespace ReceiptInformationSystem.Domain.DTOs;

public class RecipeDTO
{
    public string Description { get; set; } = string.Empty;
    public List<StepRecipeDTO> Steps { get; set; } = new();
}