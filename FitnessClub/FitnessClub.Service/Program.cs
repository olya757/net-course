using FitnessClub.Service.Controllers;
using FitnessClub.Service.IoC;
using FitnessClub.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = FitnessClubSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

AuthorizationConfigurator.ConfigureServices(builder.Services, settings);
DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);
MapperConfigurator.ConfigureServices(builder.Services);
ServicesConfigurator.ConfigureService(builder.Services, settings); //11.12.2023 - deadline

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
AuthorizationConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // create graph - search by url //localhost/users/id GET

app.Run();