namespace ReceiptInformationSystem.Domain.DTOs;

public class ReceiptDTO
{
    public string Description { get; set; } = string.Empty;
    public List<StepReceiptDTO> Steps { get; set; } = new();
}