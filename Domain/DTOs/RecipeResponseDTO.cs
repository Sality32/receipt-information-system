namespace ReceiptInformationSystem.Domain.DTOs;

public class RecipeResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<StepRecipeResponseDTO> Steps { get; set; } = new();
}