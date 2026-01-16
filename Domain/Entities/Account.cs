namespace Domain.Entities;
public class Account
{
     public int  Id{get;set;}
     public int  UserId{get;set;}
     public string Name{get;set;}=null!;
     public decimal Balance{get;set;}
}
