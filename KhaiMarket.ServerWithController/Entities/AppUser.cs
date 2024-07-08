using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KhaiMarket.ServerWithController.Entities;

public class AppUser : IdentityUser
{
    public string GivenName { get; set; } = string.Empty;
}
