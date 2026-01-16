using Infrastructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Domain.Responses;
using Domain.Entities;
public class CategoryServiceController(ICategoryService categoryService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(CategoryDto categoryDto)
    { 
       return await categoryService.AddAsync(categoryDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int categoryid)
    {
       return await categoryService.DeleteAsync(categoryid);
    }
    [HttpGet]
    public async Task<List<Category>> GetAsync()
    {
         return await categoryService.GetAsync();
    }
[HttpGet("categoruid")]
    public async Task<Response<Category>> GetByIdAsync(int categoryid)
    {
      return await categoryService.GetByIdAsync(categoryid);
    }
[HttpPut]
    public async Task<Response<string>> UpdateAsync(Category category)
    {
      return await categoryService.UpdateAsync(category);
    }
}
