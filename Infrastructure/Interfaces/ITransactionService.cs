using Domain.Responses;
using Domain.DTOs;
using Domain.Entities;
namespace Infrastructure.interfaces;

public interface ITransactionService
{
     Task<Response<string>> AddAsync(TransactionDto transactionDto); 
     Task<Response<string>> UpdateAsync(Transaction transaction); 
     Task<Response<string>> DeleteAsync(int transactionid);
     Task<Response<Transaction>> GetByIdAsync(int transactionid);
     Task<List<Transaction>> GetAsync();
}
