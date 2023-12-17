namespace FitnessClub.Service.Settings
{
    public class FitnessClubSettings
    {
        public Uri ServiceUri { get; set; }
        public string FitnessClubDbContextConnectionString { get; set; }
        public int MinimumTrainerAge { get; set; } = 18;
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}