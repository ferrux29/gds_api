using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using ApiGDS.Infraestructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("CS1");
builder.Services.AddDbContext<DataContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(connectionString));
builder.Services.AddScoped<IClienteRepository, ClientService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
