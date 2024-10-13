using Application.DTOs.Auth;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.AuthExceptions;
using Domain.Interfaces.UsuarioInterfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthService(IUsuarioRepository usuarioRepository, ICryptoService cryptoService, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            this.usuarioRepository = usuarioRepository;
            this.cryptoService = cryptoService;
            this.tokenService = tokenService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Usuario? GetUsuarioLogado()
        {
            var user = httpContextAccessor.HttpContext.User;
            if (user.Identity is { IsAuthenticated: false})
            {
                return null;
            }
            var userId = tokenService.GetUserIdFromClaimsPrincipal(user);
            var retorno = usuarioRepository.FindById(userId);

            if (retorno == null)
            {
                throw new ErroInesperadoException("Usuário não encontrado.");
            }

            return retorno;
        }

        public string logar(string login, string senha)
        {
            Usuario? user = usuarioRepository.FindByLogin(login);
            if (user != null && cryptoService.VerificarSenhaHasheada(senha, user.Senha))
            {
                return tokenService.GetToken(user);
            }
            throw new DadosIncorretosException();
        }

        public Usuario registrar(Usuario usuario)
        {
            usuario.Validate();
            usuario.Senha = cryptoService.HashearSenha(usuario.Senha);
            Usuario? user = usuarioRepository.FindByLogin(usuario.Login);
            if (user != null)
                throw new LoginIndisponivelException();

            return usuarioRepository.Save(usuario);
        }
    }
}
