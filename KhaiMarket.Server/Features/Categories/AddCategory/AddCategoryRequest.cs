namespace KhaiMarket.Server.Features.Categories;

public record AddCategoryRequest
{
    public string Name { get; set; } = string.Empty;
}