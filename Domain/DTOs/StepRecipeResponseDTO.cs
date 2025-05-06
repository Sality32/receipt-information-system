namespace ReceiptInformationSystem.Domain.DTOs;

public class StepRecipeResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ParameterStepResponseDTO> Parameters { get; set; } = new();
}