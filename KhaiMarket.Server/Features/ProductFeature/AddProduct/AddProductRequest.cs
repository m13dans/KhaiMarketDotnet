namespace KhaiMarket.Server.Features.ProductFeature.AddProduct;

public record AddProductRequest(
    string Name,
    string Description,
    int Stock,
    decimal Price,
    string ImageUrl,
    decimal DiscountPrice,
    int CategoryId,
    int BrandId,
    string SKU
);
