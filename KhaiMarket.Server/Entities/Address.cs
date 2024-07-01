using System.ComponentModel.DataAnnotations;

namespace KhaiMarket.Server.Entities;

public class Address
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(256)]
    public string AddressDetail { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string District { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string City { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string Province { get; set; } = string.Empty;
    [Required, MaxLength(10)]
    public string ZipCode { get; set; } = string.Empty;
}