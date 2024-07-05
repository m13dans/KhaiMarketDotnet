using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Features.ProductFeature;
using KhaiMarket.Server.Infrastructure;
using KhaiMarket.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient<GetProductRepository>();
builder.Services.AddTransient<GetProductService>();

var app = builder.Build();

await app.ApplyMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductEndPoint();

app.Run();