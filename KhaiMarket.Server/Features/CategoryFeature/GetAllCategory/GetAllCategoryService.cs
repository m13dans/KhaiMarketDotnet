using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.CategoryFeature.GetAllCategory;

public class GetAllCategoryService
{
    private readonly IDbConnectionFactory _db;
    public GetAllCategoryService(IDbConnectionFactory db)
    {
        _db = db;

    }
    public async Task<ErrorOr<List<Category>>> GetAllCategory()
    {
        var sql = "SELECT Id, Name FROM Categories";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.QueryAsync<Category>(sql, new { });

        if (result is null)
        {
            var error = Error.NotFound();
            return error;
        }
        return result.ToList();
    }
}