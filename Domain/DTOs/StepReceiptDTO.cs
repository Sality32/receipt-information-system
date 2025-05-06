namespace ReceiptInformationSystem.Domain.DTOs;

public class StepReceiptDTO
{
    public string Description { get; set; } = string.Empty;
    public List<ParameterStepDTO> Parameters { get; set; } = new();
}