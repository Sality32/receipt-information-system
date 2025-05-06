namespace ReceiptInformationSystem.Domain.Entities;

public class Recipe 
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public ICollection<StepRecipe> Steps { get; set; } = new List<StepRecipe>();
}