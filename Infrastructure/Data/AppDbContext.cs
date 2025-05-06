using ReceiptInformationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReceiptInformationSystem.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
  public DbSet<Receipt> Receipts => Set<Receipt>();
}