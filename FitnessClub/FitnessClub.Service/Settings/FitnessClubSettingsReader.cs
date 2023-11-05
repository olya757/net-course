namespace FitnessClub.Service.Settings
{
    public static class FitnessClubSettingsReader
    {
        public static FitnessClubSettings Read(IConfiguration configuration)
        {
            return new FitnessClubSettings()
            {
                FitnessClubDbContextConnectionString = configuration.GetValue<string>("FitnessClubDbContext")
            };
        }
    }
}
