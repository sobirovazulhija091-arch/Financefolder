using Npgsql;
namespace Domain.Data;
public class ApplicationDbcontext
{
    private readonly string connString="Host=localhost;Port=5432;Database=finance;Username=postgres;Password=1234";
     public NpgsqlConnection   Connection() => new NpgsqlConnection(connString);
}