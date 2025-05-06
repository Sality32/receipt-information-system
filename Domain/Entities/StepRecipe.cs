namespace ReceiptInformationSystem.Domain.Entities;

public class StepRecipe
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    // Foreign key
    public Guid RecipeId { get; set; }
    
    // Navigation properties
    public Recipe Recipe { get; set; } = null!;
    public ICollection<ParameterStep> Parameters { get; set; } = new List<ParameterStep>();
}