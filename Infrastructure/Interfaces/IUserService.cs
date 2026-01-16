using Domain.Responses;
using Domain.DTOs;
using Domain.Entities;
namespace Infrastructure.interfaces;

public interface IUserService
{
     Task<Response<string>> AddAsync(UserDto userDto); 
     Task<Response<string>> UpdateAsync(UpdateUserDto updateuser);
     Task<Response<string>> DeleteAsync(int userid);
     Task<Response<User>> GetByIdAsync(int userid);
     Task<List<User>> GetAsync();
}