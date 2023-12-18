using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Service.UnitTests;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly Action<IServiceCollection>? _overrideDependencies;

    public TestWebApplicationFactory(Action<IServiceCollection>? overrideDependencies = null)
    {
        _overrideDependencies = overrideDependencies;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => _overrideDependencies?.Invoke(services));
    }
}