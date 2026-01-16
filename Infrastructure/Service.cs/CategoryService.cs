using Dapper;
using Domain.Data;
using Domain.DTOs;
using Domain.Entities;
using System.Net;
using Domain.Responses;
using Infrastructure.interfaces;

public class CategoryService(ApplicationDbcontext dbcontext):ICategoryService
{
 private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<Response<string>> AddAsync(CategoryDto categoryDto)
    {
        Category category = new Category
        {
           Name=categoryDto.Name,
           CategoryType=categoryDto.CategoryType   
        };
         using var conn = _dbcontext.Connection();
         var query="insert into categories(name,categorytype) values(@name,@categorytype)";
         var res= await conn.ExecuteAsync(query,new{name=category.Name,categorytype=category.CategoryType});
          return res==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Can not added")
        :  new Response<string>(HttpStatusCode.OK,"Added successfully");
    }
    public async Task<Response<string>> DeleteAsync(int categoryid)
    {
        using var conn = _dbcontext.Connection();
        var query ="delete from categories where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=categoryid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not found id for delete"):
        new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }
    public async Task<List<Category>> GetAsync()
    {
         using var conn = _dbcontext.Connection();
        var query ="select * from categories";
        var res = await conn.QueryAsync<Category>(query);
        return res.ToList();
    }

    public async Task<Response<Category>> GetByIdAsync(int categoryid)
    {
         using var conn = _dbcontext.Connection();
        var query ="select * from categories where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Category>(query,new{Id=categoryid});
        return res==null? new Response<Category>(HttpStatusCode.NotFound,"Can not found id "):
        new Response<Category>(HttpStatusCode.OK,"Get info successfully");
    }

    public async Task<Response<string>> UpdateAsync(Category category)
    {
         using var conn = _dbcontext.Connection();
        var query ="update  categories set name=@Name,categorytype=@Categorytype where id=@Id";
        var res = await conn.ExecuteAsync(query,category);
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not update"):
        new Response<string>(HttpStatusCode.OK,"Updated successfully");
    }
}