using AscomSWEngineerTest2.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AscomSWEngineerTest2.Models;

namespace AscomSWEngineerTest2.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserRepository _userRepository;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, IUserRepository userRepository) :
           base(options, logger, encoder, clock)
        {
            _userRepository = userRepository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = Session.Username;
            string password = Session.Password;

            if (await _userRepository.Authenticate(username, password))
            {
                var claims = new[] { new Claim("name", username), new Claim(ClaimTypes.Role, "Admin") };
                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
            }

            Response.StatusCode = 401;
            return await Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }
    }
}
