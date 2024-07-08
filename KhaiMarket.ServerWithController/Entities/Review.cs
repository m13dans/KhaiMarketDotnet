using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.ServerWithController.Entities;

public class Review
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int NumStars { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AspNetUserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int ProductId { get; set; }
}
