using Infrastructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Domain.Responses;
using Domain.Entities;
using Domain.DTOs;
using System.Security.Cryptography.X509Certificates;
namespace Webfinance.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AccountServiceController(IAccountService accountService):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> AddAsync(AccountDto accountDto)
    {
        return await accountService.AddAsync(accountDto);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Account account)
    {
      return await accountService.UpdateAsync(account);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int accountid)
    {
        return await accountService.DeleteAsync(accountid);
    }
    [HttpGet("accountid")]
     public async Task<Response<Account>> GetByIdAsync(int accountid)
    {
        return await accountService.GetByIdAsync(accountid);
    }
    [HttpGet]
     public async Task<List<Account>> GetAsync()
    {
        return await accountService.GetAsync();
    }
}