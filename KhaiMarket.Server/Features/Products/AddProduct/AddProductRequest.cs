using System.ComponentModel.DataAnnotations;

namespace KhaiMarket.Server.Features.Products.AddProduct;

public record AddProductRequest
{

    [Required]
    public string Name { get; init; } = string.Empty;
    [Required]
    public string Description { get; init; } = string.Empty;
    public int Stock { get; init; }
    public decimal Price { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public decimal DiscountPrice { get; init; }
    public int? CategoryId { get; init; }
    public int? BrandId { get; init; }
    public string SKU { get; init; } = string.Empty;
}