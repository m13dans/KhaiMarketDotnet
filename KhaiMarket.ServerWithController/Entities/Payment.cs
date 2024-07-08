using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.ServerWithController.Entities;

public class Payment
{
    public int Id { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public Guid AspNetUserId { get; set; }

}
