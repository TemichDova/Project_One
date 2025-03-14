
using FluentValidation;
using Project_Transaction.Application.EntityServices.Abstraction;
using Project_Transaction.Application.Mappers;
using Project_Transaction.Application.Models.Transaction;
using Project_Transaction.Application.Models.Transaction.Abstractions;
using Project_Transaction.Dal.Repositories;
using Project_Transaction.Domain.Abstractions.Repositories.Interface;

namespace Project_Transaction.Application.EntityServices
{
    public sealed class TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, IValidator<CreateTransactionRequest> сreateTransactionRequestValidator) : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository = transactionRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IValidator<CreateTransactionRequest> _сreateTransactionRequestValidator = сreateTransactionRequestValidator;

        public async Task<CreateTransactionResponce> CreateTransaction(CreateTransactionRequest model)
        {
            await _сreateTransactionRequestValidator.ValidateAndThrowAsync(model);

            var transaction = model.ToEntity();
                        
            var entity = await _transactionRepository.GetEntity(w => w.TransactionId == transaction.TransactionId);

            if(entity != null)
            {
                return new CreateTransactionResponceNew() { InsertDateTime = entity.Created };
            }
            var asdasd = await _transactionRepository.Count();

            if (asdasd >= 100)
            {
                var oldTransactionId = await _transactionRepository.GetOldTransactionId();

                await _transactionRepository.Delete(oldTransactionId);
            }

            var createEntity = await _transactionRepository.Create(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new CreateTransactionResponceNew() { InsertDateTime = createEntity.Created };
        }

        public async Task<GetTransactionResponce> GetTransaction(Guid id)
        {
            var transaction = await _transactionRepository.Get(id);
            return transaction.ToModel();
        }
    }
}
