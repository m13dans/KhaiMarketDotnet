using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.Categories.AddCategory;

public class AddCategoryService
{
    private readonly IDbConnectionFactory _db;
    public AddCategoryService(IDbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<ErrorOr<bool>> AddCategory(string categoryName)
    {
        var sql = "INSERT INTO CATEGORIES (Name) VALUES (@Name)";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.ExecuteAsync(sql, new { Name = categoryName });

        return result is 1;
    }

    public async Task<bool> IsCategoryNameExist(string name)
    {
        var sql = "SELECT 1 FROM CATEGORIES WHERE Name LIKE @Name";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { Name = name });

        return result is 1;
    }
}
