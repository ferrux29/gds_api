using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using ApiGDS.Infraestructure.Service;
using ApiGDS.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("CS1");
builder.Services.AddDbContext<AppDbContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(connectionString));
builder.Services.AddScoped<IClienteRepository, ClientService>();
builder.Services.AddScoped<IContractRepository, ContractService>(); 
builder.Services.AddScoped<IConsultantRepository, ConsultantService>(); 
builder.Services.AddScoped<IAppendixRepository, AppendixService>();
builder.Services.AddScoped<IBillRepository, BillService>();
builder.Services.AddScoped<ITimeReportRepository, ReportService>();
builder.Services.AddScoped<IServiceRepository, ServicioService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
