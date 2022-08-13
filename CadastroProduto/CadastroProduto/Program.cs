using CadastroProduto.Application.Commands;
using CadastroProduto.Application.Control;
using CadastroProduto.Application.Queries;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;
using CadastroProduto.Service.Maps;
using CadastroProduto.Service.Repositorios;
using CadastroProduto.Service.Services;
using MediatR;
using System.Reflection;
using Vendas.Service.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Pedido
builder.Services.AddScoped<IRequestHandler<AdicionarProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<DeletarProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarPrecoProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarQuantidadeProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarParcialProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarProduto, List<BuscarProduto>>, ProdutoQueryHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarProdutoPorId, BuscarProduto>, ProdutoQueryHandler>();

// Interfaces de services
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioBase<Produto>, RepositorioBase<Produto, ProdutoMap>>();
builder.Services.AddScoped<IRepositorioBase<Categoria>, RepositorioBase<Categoria, CategoriaMap>>();

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
