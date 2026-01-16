using Domain.Responses;
using Domain.DTOs;
using Domain.Entities;
namespace Infrastructure.interfaces;

public interface ICategoryService
{
     Task<Response<string>> AddAsync(CategoryDto categoryDto); 
     Task<Response<string>> UpdateAsync(Category category); 
     Task<Response<string>> DeleteAsync(int categoryid);
     Task<Response<Category>> GetByIdAsync(int categoryid);
     Task<List<Category>> GetAsync();
}