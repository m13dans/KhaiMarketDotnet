using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.ServerWithController.Entities;

public class OrderLine
{
    public int Id { get; set; }
    public int ShoppingCartId { get; set; }
    public int ShopOrderId { get; set; }
    public decimal TotalProduct { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalPrice { get; set; }
}
