using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.Server.Entities;

public class ShipmentProvider
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal ShipmentPrice { get; set; }
}
