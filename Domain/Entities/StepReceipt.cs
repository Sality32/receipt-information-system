namespace ReceiptInformationSystem.Domain.Entities;

public class StepReceipt
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    
    // Foreign key
    public Guid ReceiptId { get; set; }
    
    // Navigation properties
    public Receipt Receipt { get; set; } = null!;
    public ICollection<ParameterStep> Parameters { get; set; } = new List<ParameterStep>();
}