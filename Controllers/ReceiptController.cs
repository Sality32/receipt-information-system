using Microsoft.AspNetCore.Mvc;
using ReceiptInformationSystem.Application.Interfaces;

namespace ReceiptInformationSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiptController : ControllerBase
{
  private readonly IReceiptService _receiptService;

  public ReceiptController(IReceiptService receiptService)
  {
    _receiptService = receiptService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _receiptService.GetReceipts());
}