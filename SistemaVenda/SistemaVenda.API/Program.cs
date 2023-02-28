using Microsoft.EntityFrameworkCore;
using SistemaVenda.API.Configurations;
using SistemaVenda.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Vendas");
builder.Services.AddDbContext<Contexto>(o => o.UseSqlServer(connectionString));

builder.Services.AddDependencyInjectionConfig();
builder.Services.AddAutoMapperConfig();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
