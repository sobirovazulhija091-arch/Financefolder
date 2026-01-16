using Domain.Entities;
namespace Domain.DTOs;
public class AccountDto
{
     public int  UserId{get;set;}
     public string Name{get;set;}=null!;
     public decimal Balance{get;set;}
}