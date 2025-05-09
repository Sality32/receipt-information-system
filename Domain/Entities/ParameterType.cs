namespace ReceiptInformationSystem.Domain.Entities;

public class ParameterType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TypeData { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}