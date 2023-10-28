using Serilog;

namespace FitnessClub.WebAPI.IoC
{
    /// <summary>
    /// Static class for serilog configuration
    /// </summary>
    public static class SerilogConfigurator
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddHttpContextAccessor();
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}
