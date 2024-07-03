using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.Server.Entities;

public class ShopOrder
{
    public int Id { get; set; }
    public Guid AspNetUserId { get; set; }
    public int ShippingAddressId {get; set;}
    public int PaymentId {get; set;}
    public int ShipmentProviderId {get; set;}
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice {get; set;}
    public string OrderStatus {get; set;} = string.Empty;
}