using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;

namespace ReceiptInformationSystem.Application.Interfaces;

public interface IReceiptService
{
    Task<IEnumerable<Receipt>> GetReceipts();
    Task<Receipt?> GetReceiptById(Guid id);
    Task<Receipt> CreateReceipt(ReceiptDTO receiptDto);
    Task<bool> UpdateReceipt(Guid id, ReceiptDTO receiptDto);
}
