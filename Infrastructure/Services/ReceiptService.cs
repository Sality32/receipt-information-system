using Microsoft.EntityFrameworkCore;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;
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

    public async Task<IEnumerable<Receipt>> GetReceipts() => 
        await _context.Receipts
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .ToListAsync();

    public async Task<Receipt?> GetReceiptById(Guid id) =>
        await _context.Receipts
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<Receipt> CreateReceipt(ReceiptDTO receiptDto)
    {
        var receipt = new Receipt
        {
            Description = receiptDto.Description,
            Steps = receiptDto.Steps.Select(s => new StepReceipt
            {
                Description = s.Description,
                Parameters = s.Parameters.Select(p => new ParameterStep
                {
                    Name = p.Name,
                    Value = p.Value,
                }).ToList()
            }).ToList()
        };

        _context.Receipts.Add(receipt);
        await _context.SaveChangesAsync();
        return receipt;
    }

    public async Task<bool> UpdateReceipt(Guid id, ReceiptDTO receiptDto)
    {
        var receipt = await _context.Receipts
            .Include(r => r.Steps)
                .ThenInclude(s => s.Parameters)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (receipt == null)
            return false;

        receipt.Description = receiptDto.Description;
        
        // Remove existing steps and parameters
        _context.ParameterSteps.RemoveRange(
            receipt.Steps.SelectMany(s => s.Parameters));
        _context.StepReceipts.RemoveRange(receipt.Steps);

        // Add new steps and parameters
        receipt.Steps = receiptDto.Steps.Select(s => new StepReceipt
        {
            Description = s.Description,
            Parameters = s.Parameters.Select(p => new ParameterStep
            {
                Name = p.Name,
                Value = p.Value,
            }).ToList()
        }).ToList();

        await _context.SaveChangesAsync();
        return true;
    }
}