using Microsoft.AspNetCore.Mvc;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReceiptDTO receiptDto)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ReceiptDTO receiptDto)
    {
        throw new NotImplementedException();
    }
}