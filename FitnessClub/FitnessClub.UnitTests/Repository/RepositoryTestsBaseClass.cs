using FitnessClub.DataAccess;
using FitnessClub.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        //13.11 - лекция по бизнес логике 
        //3 лаба включает тесты - дедлайн 13.11
        //20.11 - практика по бизнес логике - делаем лабу 4 - 27.11 включать тесты
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
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