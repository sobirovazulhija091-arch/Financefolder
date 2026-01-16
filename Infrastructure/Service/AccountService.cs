using Dapper;
using Domain.Data;
using Domain.DTOs;
using Domain.Entities;
using System.Net;
using Domain.Responses;
using Infrastructure.interfaces;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Service;

public class AccountService(ApplicationDbcontext dbcontext) : IAccountService
{
     private readonly ApplicationDbcontext _dbcontext=dbcontext;
    public async Task<Response<string>> AddAsync(AccountDto accountDto)
    {
        Account account = new Account
        {
             UserId=accountDto.UserId,
             Name=accountDto.Name,
             Balance=accountDto.Balance
        };
        using var conn = _dbcontext.Connection();
        var query="insert into accounts(userid,name,balance) values(@userid,@name,@balance)";
        var res = await conn.ExecuteAsync(query,new{userid=account.UserId,name=account.Name,balance=account.Balance});
        return res==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Can not added")
        :  new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int accountid)
    {
         using var conn = _dbcontext.Connection();
        var query ="delete from accounts where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=accountid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not found id for delete"):
        new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }

    public async  Task<List<Account>> GetAsync()
    {
        using var conn = _dbcontext.Connection();
        var query ="select * from accounts";
        var res = await conn.QueryAsync<Account>(query);
        return res.ToList();
    }

    public async Task<Response<Account>> GetByIdAsync(int accountid)
    {
        using var conn = _dbcontext.Connection();
        var query ="select * from accounts where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Account>(query,new{Id=accountid});
        return res==null? new Response<Account>(HttpStatusCode.NotFound,"Can not found id "):
        new Response<Account>(HttpStatusCode.OK,"Get info successfully");
    }

    public async Task<Response<string>> UpdateAsync(Account account)
    {
        using var conn = _dbcontext.Connection();
        var query ="update  accounts set userid=@Userid,name=@Name,balance=@Balance where id=@Id";
        var res = await conn.ExecuteAsync(query,account);
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not update"):
        new Response<string>(HttpStatusCode.OK,"Updated successfully");
    }
}