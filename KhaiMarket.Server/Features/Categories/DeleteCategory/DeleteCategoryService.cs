using Dapper;
using ErrorOr;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.Categories.DeleteCategory;

public class DeleteCategoryService
{
    private readonly IDbConnectionFactory _db;
    public DeleteCategoryService(IDbConnectionFactory db)
    {
        _db = db;
    }
    internal async Task<ErrorOr<Deleted>> DeleteCategoryAsync(int id)
    {
        var sql = "DELETE FROM Categories WHERE Id = @Id";
        using var conn = _db.CreateOpenConnection();
        var result = await conn.ExecuteAsync(sql, new { Id = id });

        if (result <= 0)
        {
            return Error.NotFound(code: "Category.NotFound",
            description: $"Category with id {id} cannot be found");
        }

        return Result.Deleted;
    }
}