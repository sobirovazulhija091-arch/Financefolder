using Infrastructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Domain.Responses;
using Domain.Entities;
using Domain.DTOs;
namespace Webfinance.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserServiceController(IUserService userService):ControllerBase
{
   
    [HttpPost]
     public async  Task<Response<string>> AddAsync(UserDto userDto)
    {
        return await userService.AddAsync(userDto);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int userid)
    {
        return await userService.DeleteAsync(userid);
    }
    [HttpGet]
     public async Task<List<User>> GetAsync()
    {
        return await userService.GetAsync();
    }
    [HttpGet("userid")]
     public async Task<Response<User>> GetByIdAsync(int userid)
    {
        return await userService.GetByIdAsync(userid);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(UpdateUserDto updateuser)
    {
        return await userService.UpdateAsync(updateuser);
    }
}