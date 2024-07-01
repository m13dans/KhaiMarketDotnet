using KhaiMarket.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KhaiMarket.Server.Infrastructure.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsUnicode(false).HasMaxLength(256);
        builder.Property(x => x.GivenName).HasMaxLength(256).IsUnicode(false);
        builder.Property(x => x.UserName).HasMaxLength(256).IsUnicode(false);
        builder.Property(x => x.Email).HasMaxLength(256).IsUnicode(false);
        builder.HasMany(x => x.Addresses).WithMany();
    }
}

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.AddressDetail).IsUnicode(false);
        builder.Property(x => x.District).IsUnicode(false);
        builder.Property(x => x.City).IsUnicode(false);
        builder.Property(x => x.Province).IsUnicode(false);
        builder.Property(x => x.ZipCode).IsUnicode(false);
    }
}