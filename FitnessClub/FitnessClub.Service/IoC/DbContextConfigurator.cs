using FitnessClub.DataAccess;
using FitnessClub.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, FitnessClubSettings settings)
    {
        services.AddDbContextFactory<FitnessClubDbContext>(
            options => { options.UseSqlServer(settings.FitnessClubDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FitnessClubDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}