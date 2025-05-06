namespace ReceiptInformationSystem.Domain.DTOs;

public class ParameterStepResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string TypeData { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}