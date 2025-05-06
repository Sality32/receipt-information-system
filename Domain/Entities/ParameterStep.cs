namespace ReceiptInformationSystem.Domain.Entities;

public class ParameterStep
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    
    // Foreign key
    public Guid StepReceiptId { get; set; }
    
    // Navigation property
    public StepReceipt StepReceipt { get; set; } = null!;
}