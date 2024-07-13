using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentValidation;
using KhaiMarket.Server.Infrastructure;
using Microsoft.VisualBasic;

namespace KhaiMarket.Server.Features.Products.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{

    public AddProductValidator(AddProductService service)
    {
        RuleFor(product => product.Name).NotEmpty().MaximumLength(256);
        RuleFor(product => product.Description).NotEmpty().Length(10, 500);
        RuleFor(p => p.CategoryId).GreaterThan(0);
        RuleFor(p => p.CategoryId)
            .MustAsync((x, c) => service.IsCategoryAvailable(x))
            .WithMessage(x => $"CategoryId {x.CategoryId} is not exist")
            .When((p) => p.CategoryId > 0, ApplyConditionTo.CurrentValidator);
        RuleFor(p => p.BrandId).GreaterThan(0);
        RuleFor(p => p.BrandId)
            .MustAsync((x, c) => service.IsBrandAvailable(x))
            .WithMessage(x => $"Brand with Id {x.BrandId} is not exist")
            .When((p) => p.BrandId > 0, ApplyConditionTo.CurrentValidator);
    }
}