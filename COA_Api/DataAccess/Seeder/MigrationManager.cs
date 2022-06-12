using Microsoft.EntityFrameworkCore;

namespace COA_Api.DataAccess.Seeder;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<CoaDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (System.Exception)
                {
                    throw;
                }                    
            }
        }
        return webApp;
    }
}
