using HealthSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace HealthSystem.Controllers
{
    [Route("api/strava/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private static readonly string ClientId = "139212";
        private static readonly string RedirectUri = "https://localhost:7089/api/strava/callback";
        private readonly StravaTokenService _tokenService;

        public ApiController(StravaTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("authorize")]
        public IActionResult Authorize()
        {
            string authorizationUrl = $"https://www.strava.com/oauth/authorize" +
                $"?client_id={ClientId}" +
                $"&redirect_uri={RedirectUri}" +
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
            //return Ok();
        }
    }
}
