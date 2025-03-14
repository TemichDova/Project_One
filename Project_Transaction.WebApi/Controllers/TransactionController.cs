using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Project_Transaction.Application.EntityServices.Abstraction;
using Project_Transaction.Application.Models.Transaction;
using Project_Transaction.Application.Models.Common;

namespace Project_Transaction.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("API для работы с производственным календарем")]
public class TransactionController(ITransactionService service) : ControllerBase
{
    private readonly ITransactionService _transactionService = service;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTransactionResponce))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> Index(CreateTransactionRequest transaction)
    {
        var response = await _transactionService.CreateTransaction(transaction);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTransactionResponce))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> Index(Guid id)
    {
        var response = await _transactionService.GetTransaction(id);
        return Ok(response);
    }
}
