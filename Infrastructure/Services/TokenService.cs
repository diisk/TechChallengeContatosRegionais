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

            var secret = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJwt")!);
            var chaveCriptografia = configuration.GetValue<string>("ChaveCrypto")!;

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("Identificador",cryptoService.CriptografarString(usuario.ID.ToString(),chaveCriptografia))
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);
        }
    }
}
