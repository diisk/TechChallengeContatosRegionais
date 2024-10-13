using Application.Interfaces;
using Domain.Entities;
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

        public TokenService(IConfiguration configuration, ICryptoService cryptoService)
        {
            this.configuration = configuration;
            this.cryptoService = cryptoService;
        }
        public string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var secret = Encoding.ASCII.GetBytes(configuration.GetValue<string>(CONFIG_KEY_SECRET)!);
            var chaveCriptografia = configuration.GetValue<string>(CONFIG_KEY_CRYPTO)!;

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(CLAIM_TYPE_ID,cryptoService.CriptografarString(usuario.ID.ToString(),chaveCriptografia))
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);
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
