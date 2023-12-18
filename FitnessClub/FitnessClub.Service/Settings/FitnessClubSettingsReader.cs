namespace FitnessClub.Service.Settings
{
    public static class FitnessClubSettingsReader
    {
        public static FitnessClubSettings Read(IConfiguration configuration)
        {
            return new FitnessClubSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                FitnessClubDbContextConnectionString = configuration.GetValue<string>("FitnessClubDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}