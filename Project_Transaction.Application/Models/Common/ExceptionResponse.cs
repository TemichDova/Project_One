using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace Project_Transaction.Application.Models.Common;

public sealed record ExceptionResponse
{
    [SwaggerSchema("Тип исключения")]
    public required string Type { get; init; }

    [SwaggerSchema("Краткое описание ошибки")]
    public required string Title { get; init; }

    [SwaggerSchema("HTTP-статус код, соответствующий ошибке")]
    public required int Status { get; init; }

    [SwaggerSchema("Подробное описание ошибки")]
    public required string Detail { get; init; }

    [SwaggerSchema("URI, который идентифицирует конкретный экземпляр ошибки")]
    public required string Instance { get; init; }

    public required ProblemDetail[] ProblemDetails { get; init; }

    public sealed record ProblemDetail
    {
        public required string Field { get; init; }
        public required string Reason { get; init; }
    }

    /*
    "errors": [
    {
      "name": "username",
      "reason": "Username is already taken."
    },
        {
          "name": "email",
          "reason": "Email format is invalid."
        }
      ]
     */
}
