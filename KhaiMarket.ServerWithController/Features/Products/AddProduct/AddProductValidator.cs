using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentValidation;
using KhaiMarket.ServerWithController.Infrastructure;
using Microsoft.VisualBasic;

namespace KhaiMarket.ServerWithController.Features.Products.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{
    private readonly CheckCategoryService _service;

    public AddProductValidator(CheckCategoryService service)
    {
        _service = service;
        RuleFor(product => product.Name).NotEmpty().MaximumLength(256);
        RuleFor(product => product.Description).NotEmpty().Length(10, 500);
        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .GreaterThan(0)
            .Must(x => int.TryParse(x.ToString(), out int result)).WithMessage("Must be an int number")
            .MustAsync((x, c) => _service.IsCategoryAvailable(x))
            .WithMessage(x => $"CategoryId {x.CategoryId} is not exist");

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