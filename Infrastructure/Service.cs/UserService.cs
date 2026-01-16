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
            if(res == null)
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
    public Task<Response<string>> DeleteAsync(int userid)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<User>> GetByIdAsync(int userid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}