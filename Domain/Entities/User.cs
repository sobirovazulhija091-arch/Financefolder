namespace Domain.Entities;
public class User
{
   public int  Id{get;set;}
   public string UserName{get;set;}=null!;
   public DateTime RegisteredAt{get;set;}=DateTime.UtcNow;
}
