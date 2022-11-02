using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using System.Runtime.CompilerServices;

namespace MartianRobots.API.Security
{
    /// <summary>
    /// The APIBasicAuthenticationHandler class for basic security.
    /// </summary>
    public class APIBasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// The defaul user name.
        /// </summary>
        private const string DefaulUserName = "Admin";

        /// <summary>
        /// The defaul password.
        /// </summary>
        private const string DefaulPassword = "Admin";

        /// <summary>
        /// The APIBasicAuthenticationHandler constructor.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="encoder"></param>
        /// <param name="clock"></param>
        public APIBasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) :
            base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// The authenticate handle method.
        /// </summary>
        /// <returns>A task with the authenticate result </returns>
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring("Basic ".Length).Trim();
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialstring.Split(':');

                if (credentials[0] == DefaulUserName && credentials[1] == DefaulPassword)
                {
                    var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    var claimsPrincipal = new ClaimsPrincipal(identity);

                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }

                Response.StatusCode = 401;

                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
            else
            {
                Response.StatusCode = 401;

                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }
    }
}
