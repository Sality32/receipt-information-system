namespace ReceiptInformationSystem.Domain.DTOs;

public class StepRecipeDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ParameterStepDTO> Parameters { get; set; } = new();
}