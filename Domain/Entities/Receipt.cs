namespace ReceiptInformationSystem.Domain.Entities;

public class Receipt 
{
  public Guid Id { get; set; }
  public string Description { get; set;} = string.Empty;
}
