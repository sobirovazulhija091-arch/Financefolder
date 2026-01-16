using System.Net;
namespace Domain.Responses;
public class Response<T>
{
    public int StatusCode{get;set;}
    public T? Data{get;set;}
    public List<string> Description{get;set;}=[];
    public Response(HttpStatusCode statusCode,T data,string message)
    {
         StatusCode=(int)statusCode;
         Description.Add(message);
         Data=data;
    }
     public Response(HttpStatusCode statusCode,T data,List<string> message)
    {
         StatusCode=(int)statusCode;
         Description=message;
         Data=data;
    }
     public Response(HttpStatusCode statusCode,string message)
    {
         StatusCode=(int)statusCode;
         Description.Add(message);
    }
      public Response(HttpStatusCode statusCode,List<string> message)
    {
         StatusCode=(int)statusCode;
         Description=message;
    }
}