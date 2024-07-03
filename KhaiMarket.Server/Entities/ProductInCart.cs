using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.Server.Entities;

public class ProductInCart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShoppingCartId { get; set; }
    public int ProductQty { get; set; }
}
