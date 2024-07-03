using System.Reflection;
using KhaiMarket.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KhaiMarket.Server.Infrastructure;

public class EFDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // make sure to call the base if configuring the IdentityTable 
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
