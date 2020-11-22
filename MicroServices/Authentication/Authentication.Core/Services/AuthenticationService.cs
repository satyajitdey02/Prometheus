using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Authentication.Core.DBEntities;
using Authentication.Core.DTOs;
using Authentication.Core.Interfaces.Repositories;
using Authentication.Core.Interfaces.Services;
using Framework.Core.Extensions;
using Framework.Core.Jwt;
using Framework.Core.Logger;
using Framework.Core.Utility;
using Microsoft.Extensions.Options;

namespace Authentication.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IAuthenticationManagementRepository _authenticationManagementRepository;
        private readonly IProLogger _proLogger;

        public AuthenticationService(
            IOptions<JwtIssuerOptions> jwtOptions,
            IAuthenticationManagementRepository authenticationManagementRepository,
            IProLogger proLogger)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);

            _authenticationManagementRepository = authenticationManagementRepository;
            _proLogger = proLogger;
        }

        public async Task<AuthenticateResponseDTO> AuthenticationAsync(AuthenticateRequestDTO dto)
        {
            AuthenticateResponseDTO authenticateResponse = null;

            await TryCatchExtension.ExecuteAndHandleErrorAsync(
                async () =>
                {
                    var login = await _authenticationManagementRepository
                        .LoginRepository
                        .FindAsync<Employee>(x => x.UserName == dto.UserName && x.Password == dto.Password.GetString(), x => x.Employee);

                    var jwtToken = await GenerateJwtTokenAsync(login, GenerateClaimsIdentity(login.UserName, login.Id));

                    authenticateResponse = AuthenticateResponseDTO.Create(login.Id, login.UserName, login.Employee.RoleId, jwtToken, true);
                },
                ex =>
                {
                    _proLogger.Error($"An error occurred while authenticating the user having username: {dto.UserName}. Error: {ex.Message}");

                    return false;
                });

            return authenticateResponse;
        }

        private async Task<string> GenerateJwtTokenAsync(Login login, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst(Constants.Constants.Jwt.ClaimIdentifiers.Rol),
                identity.FindFirst(Constants.Constants.Jwt.ClaimIdentifiers.Id)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private ClaimsIdentity GenerateClaimsIdentity(string userName, int id)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Constants.Constants.Jwt.ClaimIdentifiers.Id, id.ToString()),
                new Claim(Constants.Constants.Jwt.ClaimIdentifiers.Rol, Constants.Constants.Jwt.Claims.ApiAccess)
            });
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private long ToUnixEpochDate(DateTime date) => (date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).Ticks;

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
