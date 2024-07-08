using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.ServerWithController.Entities;

public class UserShoppingCart
{
    public int Id { get; set; }
    public Guid AspNetUserId { get; set; }
}
