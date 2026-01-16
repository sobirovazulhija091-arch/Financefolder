using Domain.Data;
using Infrastructure.interfaces;
using Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IUserService ,UserService>();
builder.Services.AddControllers();
builder.Services.AddScoped<ApplicationDbcontext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(config=>{config.AddConsole();});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

 app.MapControllers();
//  app.UseMiddleware<>();
app.MapOpenApi();
app.Run();

