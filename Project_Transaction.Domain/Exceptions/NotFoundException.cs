using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Project_Transaction.Domain.Exceptions;

public sealed class NotFoundException(string message = "Не найдено") : Exception
{
    public override string Message => message;

    public override IDictionary Data => new Dictionary<string, int> { { "status", StatusCodes.Status404NotFound } };
}
