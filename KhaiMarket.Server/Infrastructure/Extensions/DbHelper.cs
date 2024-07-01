using Microsoft.EntityFrameworkCore;

namespace KhaiMarket.Server.Infrastructure.Extensions;

public static class DbHelper
{
    public async static Task ApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<EFDbContext>();
        await context!.Database.MigrateAsync();
    }
}
