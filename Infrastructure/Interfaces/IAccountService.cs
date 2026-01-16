using Domain.Responses;
using Domain.DTOs;
using Domain.Entities;
namespace Infrastructure.interfaces;
public interface IAccountService
{
   
     Task<Response<string>> AddAsync(AccountDto accountDto); 
     Task<Response<string>> UpdateAsync(Account account); 
     Task<Response<string>> DeleteAsync(int accountid);
     Task<Response<Account>> GetByIdAsync(int accountid);
     Task<List<Account>> GetAsync();
}