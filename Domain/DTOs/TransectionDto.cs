namespace Domain.DTOs;
public class TransactionDto
{
     public int CategoryId{get;set;}
     public int AccountId{get;set;}
     public decimal Amount{get;set;}
     public string Description{get;set;}=null!;   

}