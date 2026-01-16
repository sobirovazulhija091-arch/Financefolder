using Infrastructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Domain.Responses;
using Domain.Entities;
using Domain.DTOs;
namespace Webfinance.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TransactionServiceCotroller(ITransactionService transactionService):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> AddAsync(TransactionDto transactionDto)
    { 
       return await transactionService.AddAsync(transactionDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int transactionid)
    {
       return await  transactionService.DeleteAsync(transactionid);
    }
   [HttpGet]
    public async Task<List<Transaction>> GetAsync()
    {
       return await transactionService.GetAsync();
    }
   [HttpGet("transactionid")]
    public async Task<Response<Transaction>> GetByIdAsync(int transactionid)
    {
        return await transactionService.GetByIdAsync(transactionid);
    }

    public async Task<Response<string>> UpdateAsync(Transaction transaction){}
}