using Newtonsoft.Json.Linq;

namespace HealthSystem.Data
{
    public class StravaAuth
    {
        private static readonly string ClientId = "139212";
        private static readonly string ClientSecret = "ba90e22d0d197019c6b39f67d7479be6d60320ad";

        public static async Task<string> GetAccessToken(string code)
        {
            using HttpClient client = new();
            var values = new Dictionary<string, string>
            {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "code", code },
                { "grant_type", "authorization_code" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var tokenObject = JObject.Parse(responseString);
            string accessToken = tokenObject["access_token"]?.ToString();

            return accessToken;
        }
    }
}
