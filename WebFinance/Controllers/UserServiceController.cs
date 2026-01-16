using Infrastructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Domain.Responses;
using Domain.Data;
using Domain.DTOs;
namespace Domain.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserServiceController(IUserService userService):ControllerBase
{
   
    [HttpPost]
     public async  Task<Response<string>> AddAsync(UserDto userDto)
    {
        return await userService.AddAsync(userDto);
    }
}