using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService : ITokenService
    {

        private const string CLAIM_TYPE_ID = "Identificador";
        private const string CONFIG_KEY_SECRET = "SecretJwt";
        private const string CONFIG_KEY_CRYPTO = "ChaveCrypto";

        private readonly IConfiguration configuration;
        private readonly ICryptoService cryptoService;
        private readonly ICacheService cacheService;

        public TokenService(IConfiguration configuration, ICryptoService cryptoService, ICacheService cacheService)
        {
            this.configuration = configuration;
            this.cryptoService = cryptoService;
            this.cacheService = cacheService;
        }

        public string GetToken(Usuario usuario)
        {
            var chaveCache = $"TOKEN_{usuario.ID}";
            var tokenString = cacheService.GetCache(chaveCache);

            if (tokenString != null)
            {
                return (string)tokenString;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(configuration.GetValue<string>(CONFIG_KEY_SECRET)!);
            var chaveCriptografia = configuration.GetValue<string>(CONFIG_KEY_CRYPTO)!;

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(CLAIM_TYPE_ID,cryptoService.CriptografarString(usuario.ID.ToString(),chaveCriptografia))
                }),

                Expires = DateTime.UtcNow.AddHours(9),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            tokenString = tokenHandler.WriteToken(token);
            cacheService.SetCache(chaveCache, tokenString, TimeSpan.FromHours(8));
            return (string)tokenString;
        }

        public int GetUserIdFromClaimsPrincipal(ClaimsPrincipal user)
        {
            var chaveCriptografia = configuration.GetValue<string>(CONFIG_KEY_CRYPTO)!;

            var idEncryptado = user.FindFirst(CLAIM_TYPE_ID)!.Value;

            var id = Convert.ToInt32(cryptoService.DescriptografarString(idEncryptado, chaveCriptografia));

            return id;
        }
    }
}
