using FitnessClub.Service.Settings;
using Microsoft.Extensions.Configuration;

namespace FitnessClub.Service.Autotests.Helpers;

public static class TestHttpClientFactory
{
    public static HttpClient CreateHttpClient()
    {
        var settings = TestSettingsHelper.GetSettings();
        return new HttpClient()
        {
            BaseAddress = settings.ServiceUri
        };
    }

    public static HttpClient CreateHttpClient(string jwtToken)
    {
        var settings = TestSettingsHelper.GetSettings();
        var authHeaderValue = "Bearer " + jwtToken;
        return new HttpClient()
        {
            BaseAddress = settings.ServiceUri,
            DefaultRequestHeaders =
            {
                { "Authorization", jwtToken }
            }
        }; 
    }

}