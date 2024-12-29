using HealthSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace HealthSystem.Controllers
{
    [Route("api/strava/")]
    [ApiController]
    public class ApiController(StravaTokenService tokenService) : ControllerBase
    {
        private static readonly string _clientId = "139212";
        private static readonly string _redirectUri = "https://localhost:7089/api/strava/callback";
        private readonly StravaTokenService _tokenService = tokenService;

        [HttpGet("authorize")]
        public IActionResult Authorize()
        {
            string authorizationUrl = $"https://www.strava.com/oauth/authorize" +
                $"?client_id={_clientId}" +
                $"&redirect_uri={_redirectUri}" +
                $"&response_type=code" +
                $"&scope=activity:read_all";

            return Redirect(authorizationUrl);
        }

        [HttpGet("callback")]
        public IActionResult Callback([FromQuery] string code)
        {
            string accessToken = StravaAuth.GetAccessToken(code).Result;
            _tokenService.AccessToken = accessToken;

            return Content(@"<script>window.close();</script>", "text/html");
        }
    }
}
