using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Project_Transaction.Application.EntityServices.Abstraction;
using Project_Transaction.Application.Models.Transaction;

namespace Project_Transaction.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("API для работы с производственным календарем")]
public class TransactionController(ITransactionService service) : ControllerBase
{
    private readonly ITransactionService _transactionService = service;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTransactionResponceNew))]
    public async Task<IActionResult> Index(CreateTransactionRequest transaction)
    {
        var response = await _transactionService.CreateTransaction(transaction);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTransactionResponce))]
    public async Task<IActionResult> Index(Guid id)
    {
        var response = await _transactionService.GetTransaction(id);
        return Ok(response);
    }
}
