namespace KhaiMarket.Server.Features.CategoryFeature;

public record AddCategoryRequest
{
    public string Name { get; set; } = string.Empty;
}