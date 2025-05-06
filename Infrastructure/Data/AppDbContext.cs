using ReceiptInformationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReceiptInformationSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ParameterStep> ParameterSteps => Set<ParameterStep>();
    public DbSet<ParameterType> ParameterTypes => Set<ParameterType>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<StepRecipe> StepRecipes => Set<StepRecipe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // New relationship
        modelBuilder.Entity<ParameterStep>()
            .HasOne(p => p.StepRecipe)
            .WithMany(s => s.Parameters)
            .HasForeignKey(p => p.StepRecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure enum as string
        modelBuilder.Entity<ParameterStep>()
            .Property(p => p.Type)
            .HasConversion<string>();

        modelBuilder.Entity<StepRecipe>()
            .HasOne(s => s.Recipe)
            .WithMany(r => r.Steps)
            .HasForeignKey(s => s.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }    
}    