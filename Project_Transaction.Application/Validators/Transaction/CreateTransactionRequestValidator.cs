using FluentValidation;
using Project_Transaction.Application.Models.Transaction;

namespace Project_Transaction.Application.Validators.Transaction
{
    public sealed partial class CreateTransactionRequestValidator : AbstractValidator<CreateTransactionRequest>
    {
        public CreateTransactionRequestValidator()
        {
            RuleFor(r => r.Amount).Must(x => x > 0).WithMessage("Сумма не корректна");
            RuleFor(r => r.TransactionDate).Must(x => x < DateTime.Now).WithMessage("Дата не корректна");
        }
    }
}
