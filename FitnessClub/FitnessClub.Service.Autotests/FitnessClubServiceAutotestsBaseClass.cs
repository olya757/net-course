using FitnessClub.Service.Autotests.Helpers;
using FitnessClub.Service.IoC;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace FitnessClub.Service.Autotests;

public class FitnessClubServiceAutotestsBaseClass
{
    public FitnessClubServiceAutotestsBaseClass()
    {
        var services = new ServiceCollection();
        var settings = TestSettingsHelper.GetSettings();

        AuthorizationConfigurator.ConfigureServices(services, settings);
        DbContextConfigurator.ConfigureService(services, settings);
        MapperConfigurator.ConfigureServices(services);
        ServicesConfigurator.ConfigureService(services, settings);


        _testServer = new TestServer(services.BuildServiceProvider());
    }

    public T? GetService<T>() => _testServer.Services.GetService<T>();
    private readonly TestServer _testServer;
    protected HttpClient TestHttpClient => _testServer.CreateClient();
}