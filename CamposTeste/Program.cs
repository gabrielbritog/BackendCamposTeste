using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Interface;
using CamposTeste.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDefaultService<Produto>, ProdutoService>();
builder.Services.AddScoped<IDefaultService<Cliente>, ClienteService>();
builder.Services.AddScoped<IDefaultService<Venda>, VendaService>();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
