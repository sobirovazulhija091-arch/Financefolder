namespace Domain.Entities;
public class Transaction
{
     public int Id{get;set;}
     public int CategoryId{get;set;}
     public int AccountId{get;set;}
     public decimal Amount{get;set;}
     public string Description{get;set;}=null!;
     public DateTime CreateAt{get;set;}=DateTime.UtcNow;
}