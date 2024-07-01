using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KhaiMarket.Server.Entities;

public class AppUser : IdentityUser
{
    public string GivenName { get; set; } = string.Empty;
    public ICollection<Address> Addresses { get; set; } = [];
}
