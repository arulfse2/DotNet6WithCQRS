using WebApi.Data;
namespace WebApi;
public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            // using (var appContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>())
            using (var appContext = scope.ServiceProvider.GetRequiredService<CqrsDbContext>())
            {
                try
                {
                    DataSeeder.SeedAuthors(appContext);
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }

        return webApp;
    }
}