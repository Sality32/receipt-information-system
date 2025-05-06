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

        
        // Seed ParameterType data
        modelBuilder.Entity<ParameterType>().HasData(
            new ParameterType
            {
                Id = Guid.Parse("35fee709-1568-495c-9163-7ee9ddf7784a"),
                Name = "Deskripsi",
                TypeData = "text",
                Description = "Penjelasan tentang langkah"
            },
            new ParameterType
            {
                Id = Guid.Parse("b4e54ea5-9e64-42db-8fcc-ff3dd25e085e"),
                Name = "Durasi",
                TypeData = "integer",
                Description = "Lama waktu pelaksanaan langkah"
            },
            new ParameterType
            {
                Id = Guid.Parse("be0c8dd8-93db-494a-8a27-8fc69e4bf01e"),
                Name = "Suhu",
                TypeData = "float",
                Description = "Suhu yang dibutuhkan"
            },
            new ParameterType
            {
                Id = Guid.Parse("c40582ab-bfcd-4a7e-bf54-33ef61aec5ed"),
                Name = "tekanan",
                TypeData = "float",
                Description = "Tekanan pada alat yang digunakan"
            }
        );
    }    
}