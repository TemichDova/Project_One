
using FluentValidation;
using Project_Transaction.Application.EntityServices.Abstraction;
using Project_Transaction.Application.Mappers;
using Project_Transaction.Application.Models.Transaction;
using Project_Transaction.Dal.Repositories;
using Project_Transaction.Domain.Abstractions.Repositories.Interface;
using System.Transactions;

namespace Project_Transaction.Application.EntityServices
{
    public sealed class TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, IValidator<CreateTransactionRequest> сreateTransactionRequestValidator) : ITransactionService
    {
        
        private readonly ITransactionRepository _transactionRepository = transactionRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IValidator<CreateTransactionRequest> _createTransactionRequestValidator = сreateTransactionRequestValidator;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);


        public async Task<CreateTransactionResponse> CreateTransaction(CreateTransactionRequest model)
        {
            await _createTransactionRequestValidator.ValidateAndThrowAsync(model);

            var transaction = model.ToEntity();
            await _semaphore.WaitAsync();

            try
            {
                var entity = await _transactionRepository.GetEntity(w => w.TransactionId == transaction.TransactionId);

                if (entity != null)
                {
                    return new CreateTransactionResponse() { InsertDateTime = entity.Created };
                }
                var transactionsCount = await _transactionRepository.Count();

                if (transactionsCount >= 100)
                {
                    var oldTransactionId = await _transactionRepository.GetOldTransactionId();

                    await _transactionRepository.Delete(oldTransactionId);
                }

                var createEntity = await _transactionRepository.Create(transaction);
                await _unitOfWork.SaveChangesAsync();


                return new CreateTransactionResponse() { InsertDateTime = createEntity.Created };
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<GetTransactionResponce> GetTransaction(Guid id)
        {
            var transaction = await _transactionRepository.Get(id);
            return transaction.ToModel();
        }
    }
}
