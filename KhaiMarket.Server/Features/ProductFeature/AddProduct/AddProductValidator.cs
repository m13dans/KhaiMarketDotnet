using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentValidation;
using KhaiMarket.Server.Infrastructure;
using Microsoft.VisualBasic;

namespace KhaiMarket.Server.Features.ProductFeature.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{
    private readonly CheckCategoryService _service;

    public AddProductValidator(CheckCategoryService service)
    {
        _service = service;
        RuleFor(product => product.Name).NotEmpty().MaximumLength(256);
        RuleFor(product => product.Description).NotEmpty().Length(10, 500);
        RuleFor(p => p.CategoryId)
            .GreaterThan(0);
        RuleFor(p => p.CategoryId)
            .MustAsync((x, c) => _service.IsCategoryAvailable(x))
            .WithMessage(x => $"CategoryId {x.CategoryId} is not exist")
            .When((p) => p.CategoryId > 0, ApplyConditionTo.CurrentValidator);
    }
}

public class CheckCategoryService
{
    private readonly IDbConnectionFactory _db;
    public CheckCategoryService(IDbConnectionFactory db)
    {
        _db = db;

    }
    public async Task<bool> IsCategoryAvailable(int id)
    {
        var sql = "SELECT 1 FROM CATEGORIES WHERE Id = @Id";
        var connection = _db.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { Id = id });

        return result == 1;
    }
}