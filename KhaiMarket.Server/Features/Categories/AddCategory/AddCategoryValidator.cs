using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentValidation;
using KhaiMarket.Server.Features.Categories.AddCategory;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.Categories;

public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
{
    public AddCategoryValidator(AddCategoryService service)
    {
        RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(100)
            .MustAsync(async (n, c) => !await service.IsCategoryNameExist(n))
            .WithMessage(x => $"Category with name {x.Name} already exist");
    }
}