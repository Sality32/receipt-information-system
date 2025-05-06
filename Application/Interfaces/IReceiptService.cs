using ReceiptInformationSystem.Domain.Entities;

namespace ReceiptInformationSystem.Application.Interfaces;

public interface IReceiptService
{
  Task<IEnumerable<Receipt>> GetReceipts();
}
