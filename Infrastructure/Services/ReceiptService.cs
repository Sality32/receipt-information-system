using Microsoft.EntityFrameworkCore;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.Entities;
using ReceiptInformationSystem.Infrastructure.Data;

namespace ReceiptInformationSystem.Infrastructure.Services;

public class ReceiptService : IReceiptService 
{
  private readonly AppDbContext _context;

  public ReceiptService(AppDbContext context) 
  {
    _context = context;
  }

  public async Task<IEnumerable<Receipt>> GetReceipts() => await _context.Receipts.ToListAsync();
}