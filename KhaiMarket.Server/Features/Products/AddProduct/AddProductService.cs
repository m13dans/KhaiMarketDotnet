using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.Products.AddProduct;

public class AddProductService(IDbConnectionFactory db)
{
    private readonly IDbConnectionFactory _db = db;
    public async Task<ErrorOr<Product>> AddProduct(AddProductRequest product)
    {
        var sql = $"""
            INSERT INTO Products (
                Name,
                Description,
                Stock,
                Price,
                ImageUrl,
                DiscountPrice,
                CategoryId,
                BrandId,
                SKU,
                CreatedAt,
                LastModifiedAt
            ) VALUES (
                @Name,
                @Description,
                @Stock,
                @Price,
                @ImageUrl,
                @DiscountPrice,
                @CategoryId,
                @BrandId,
                @SKU,
                @CreatedAt,
                @LastModifiedAt
            )
            
            SELECT CAST (SCOPE_IDENTITY() AS INT)
        """;
        using var connection = _db.CreateOpenConnection();
        int id = await connection.QuerySingleOrDefaultAsync<int>(
            sql,
            param: new
            {
                product.Name,
                product.Description,
                product.Stock,
                product.Price,
                product.ImageUrl,
                product.DiscountPrice,
                product.CategoryId,
                product.BrandId,
                product.SKU,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now
            });

        Product productResponse = await connection.QuerySingleAsync<Product>(
            sql: "SELECT * FROM Products WHERE Id = @Id",
            param: new { Id = id });

        return productResponse;
    }

    public async Task<bool> IsCategoryAvailable(int? id)
    {
        var sql = "SELECT 1 FROM CATEGORIES WHERE Id = @Id";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { Id = id });

        return result == 1;
    }
    public async Task<bool> IsBrandAvailable(int? id)
    {
        var sql = "SELECT 1 FROM BRANDS WHERE Id = @Id";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { Id = id });

        return result == 1;
    }
}