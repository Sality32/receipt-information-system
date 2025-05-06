namespace ReceiptInformationSystem.Domain.Entities;

public class ParameterStep
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    
    // Foreign key
    public Guid StepRecipeId { get; set; }
    
    // Navigation property
    public StepRecipe StepRecipe { get; set; } = null!;
}