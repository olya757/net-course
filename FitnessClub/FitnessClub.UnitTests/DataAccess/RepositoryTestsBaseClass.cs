using FitnessClub.DataAccess;
using FitnessClub.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.UnitTests.DataAccess;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        Settings = FitnessClubSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<FitnessClubDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<FitnessClubDbContext>(
            options => { options.UseSqlServer(Settings.FitnessClubDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly FitnessClubSettings Settings;
    protected readonly IDbContextFactory<FitnessClubDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}