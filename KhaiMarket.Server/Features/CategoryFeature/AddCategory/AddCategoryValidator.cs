using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentValidation;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.CategoryFeature;

public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
{
    public AddCategoryValidator(CategoryValidatorService service)
    {
        RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(100)
            .MustAsync(async (n, c) => !await service.IsCategoryNameExist(n))
            .WithMessage(x => $"Category with name {x.Name} already exist");
    }
}

public class CategoryValidatorService
{
    private readonly IDbConnectionFactory _db;
    public CategoryValidatorService(IDbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<bool> IsCategoryNameExist(string name)
    {
        var sql = "SELECT 1 FROM CATEGORIES WHERE Name LIKE @Name";
        using var connection = _db.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { Name = name });

        return result is 1;
    }
}
