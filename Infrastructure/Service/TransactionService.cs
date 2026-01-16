using System.ComponentModel;
using Dapper;
using Domain.Data;
using Domain.DTOs;
using Domain.Entities;
using System.Net;
using Domain.Responses;
using Infrastructure.interfaces;

public class TransactionService(ApplicationDbcontext dbcontext) : ITransactionService
{
    private readonly ApplicationDbcontext _dbcontext=dbcontext;
    public async Task<Response<string>> AddAsync(TransactionDto transactionDto)
    { 
       Transaction transaction = new Transaction
       {
           AccountId=transactionDto.AccountId,
           CategoryId=transactionDto.CategoryId,
           Amount=transactionDto.Amount,
           Description=transactionDto.Description
       };  
       using var  conn = _dbcontext.Connection();
       var query = "insert into transactions(accoundid,categoryid,amount,description) values(@accoundid,@categoryid,@amount,@description)";
       var res=await conn.ExecuteAsync(query,new{accountid=transaction.AccountId,categoryid=transaction.CategoryId,amount=transaction.Amount,description=transaction.Description});
         return res==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Can not added")
        :  new Response<string>(HttpStatusCode.OK,"Added successfully");
    }
    public async Task<Response<string>> DeleteAsync(int transactionid)
    {
        using var conn = _dbcontext.Connection();
        var query ="delete from transactions where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=transactionid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not found id for delete"):
        new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }

    public async Task<List<Transaction>> GetAsync()
    {
        using var conn = _dbcontext.Connection();
        var query ="select * from transaction";
        var res = await conn.QueryAsync<Transaction>(query);
        return res.ToList();
    }

    public async Task<Response<Transaction>> GetByIdAsync(int transactionid)
    {
        using var conn = _dbcontext.Connection();
        var query ="select * from transactions where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Transaction>(query,new{Id=transactionid});
        return res==null? new Response<Transaction>(HttpStatusCode.NotFound,"Can not found id "):
        new Response<Transaction>(HttpStatusCode.OK,"Get info successfully");
    }

    public async Task<Response<string>> UpdateAsync(Transaction transaction)
    {
        var conn = _dbcontext.Connection();
        var query ="update transection accountid,categoryid,amount,description where id=@Id";
        var res= await conn.ExecuteAsync(query ,transaction);
        return res==0 ? new Response<string>(HttpStatusCode.NotFound,"Can not find for update")
        : new Response<string>(HttpStatusCode.OK,"Update successufully");
    }
}