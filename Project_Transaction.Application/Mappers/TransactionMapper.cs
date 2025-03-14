using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Transaction.Application.Models.Transaction;
using Project_Transaction.Domain.Entities;

namespace Project_Transaction.Application.Mappers;

internal static class TransactionMapper
{
    public static Transaction ToEntity(this CreateTransactionRequest model) => new Transaction() { TransactionId = model.Id, TransactionDate = model.TransactionDate, Amount = model.Amount };
    public static GetTransactionResponce ToModel(this Transaction entity) => new GetTransactionResponce() { Amount = entity.Amount, Id = entity.TransactionId, TransactionDate = entity.TransactionDate };

}
