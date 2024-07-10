using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.CategoryFeature.AddCategory;

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
}
