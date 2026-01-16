using Domain.Data;
using Domain.DTOs;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.interfaces;

public class TransactionService(ApplicationDbcontext dbcontext) : ITransactionService
{
    public Task<Response<string>> AddAsync(TransactionDto transactionDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DeleteAsync(int transactionid)
    {
        throw new NotImplementedException();
    }

    public Task<List<Transaction>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<Transaction>> GetByIdAsync(int transactionid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}