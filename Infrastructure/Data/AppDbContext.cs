using ReceiptInformationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReceiptInformationSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<StepReceipt> StepReceipts => Set<StepReceipt>();
    public DbSet<ParameterStep> ParameterSteps => Set<ParameterStep>();
    public DbSet<ParameterType> ParameterTypes => Set<ParameterType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Existing relationship
        modelBuilder.Entity<StepReceipt>()
            .HasOne(s => s.Receipt)
            .WithMany(r => r.Steps)
            .HasForeignKey(s => s.ReceiptId)
            .OnDelete(DeleteBehavior.Cascade);

        // New relationship
        modelBuilder.Entity<ParameterStep>()
            .HasOne(p => p.StepReceipt)
            .WithMany(s => s.Parameters)
            .HasForeignKey(p => p.StepReceiptId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure enum as string
        modelBuilder.Entity<ParameterStep>()
            .Property(p => p.Type)
            .HasConversion<string>();
    }
}