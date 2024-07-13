using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Features.Products;
using KhaiMarket.Server.Infrastructure;
using KhaiMarket.Server.Infrastructure.Extensions;
using KhaiMarket.Server.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using KhaiMarket.Server.Features.Products.AddProduct;
using KhaiMarket.Server.Features.Categories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("SQLExpress")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<EFDbContext>();


builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddProductServices();
builder.Services.AddCategoryServices();

builder.Services.AddScoped<IValidator<AddProductRequest>, AddProductValidator>();
builder.Services.AddScoped<IValidator<AddCategoryRequest>, AddCategoryValidator>();

builder.Services.AddExceptionHandler<GlobalExeption>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
await app.ApplyMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductEndPoint();
app.MapCategoryEndpoint();

app.Run();