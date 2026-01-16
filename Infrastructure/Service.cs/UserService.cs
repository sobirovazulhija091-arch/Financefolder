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
public class UserService(ApplicationDbcontext dbcontext,ILogger<User> logger) : IUserService
{
    private readonly ILogger<User> _logger=logger;
    private readonly ApplicationDbcontext _dbcontext=dbcontext;
    public async  Task<Response<string>> AddAsync(UserDto userDto)
    {
        try
        {
             _logger.LogInformation("Stared successfully");
             using var conn = _dbcontext.Connection();
             User user = new User
             {
                UserName=userDto.UserName 
             };
            var query ="insert into users(username) values(@Username)";
            var res = await conn.ExecuteAsync(query , new{username=user.UserName});
            if(res == 0)
             { 
                return new Response<string>(HttpStatusCode.InternalServerError,"Can not added");
             }
            else
            {
                             return new Response<string>(HttpStatusCode.OK,"Added user successfuly!");
            }
        }
        catch (System.Exception ex)
        {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        using var conn = _dbcontext.Connection();
        var query ="delete from users where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=userid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not found id for delete"):
        new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }

    public async Task<List<User>> GetAsync()
    {
       using var conn = _dbcontext.Connection();
        var query ="select * from users";
        var res = await conn.QueryAsync<User>(query);
        return res.ToList();
    }

    public async Task<Response<User>> GetByIdAsync(int userid)
    {
       using var conn = _dbcontext.Connection();
        var query ="select * from users where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<User>(query,new{Id=userid});
        return res==null? new Response<User>(HttpStatusCode.NotFound,"Can not found id "):
        new Response<User>(HttpStatusCode.OK,"Get info successfully");
    }

    public async Task<Response<string>> UpdateAsync(UpdateUserDto updateuser)
    {
         using var conn = _dbcontext.Connection();
        var query ="update  users set username=@Username where id=@Id";
        var res = await conn.ExecuteAsync(query,updateuser);
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not update"):
        new Response<string>(HttpStatusCode.OK,"Updated successfully");
    }
}