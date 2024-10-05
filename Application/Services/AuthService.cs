using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICryptoService cryptoService;
        private readonly ITokenService tokenService;

        public AuthService(IUsuarioRepository usuarioRepository, ICryptoService cryptoService, ITokenService tokenService)
        {
            this.usuarioRepository = usuarioRepository;
            this.cryptoService = cryptoService;
            this.tokenService = tokenService;
        }

        public string logar(string email, string senha)
        {
            Usuario? user = usuarioRepository.FindByEmail(email);
            if (user != null && cryptoService.VerificarSenhaHasheada(senha, user.SenhaHasheada))
            {
                return tokenService.GetToken(user);
            }
            throw new Exception("Email ou senha incorretos.");
        }

        public Usuario registrar(string email, string senha)
        {
            Usuario? user = usuarioRepository.FindByEmail(email);
            if (user != null)
                throw new Exception("Já existe um usuário cadastrado com esse email.");

            var senhaHasheada = cryptoService.HashearSenha(senha);

            var usuario = new Usuario { Email = email, SenhaHasheada = senhaHasheada };

            usuario.Validate();

            return usuarioRepository.Save(usuario);

        }
    }
}
