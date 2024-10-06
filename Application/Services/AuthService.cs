using Application.DTOs.Auth;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.AuthExceptions;
using Domain.Interfaces.UsuarioInterfaces;
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

        public string logar(string login, string senha)
        {
            Usuario? user = usuarioRepository.FindByLogin(login);
            if (user != null && cryptoService.VerificarSenhaHasheada(senha, user.SenhaHasheada))
            {
                return tokenService.GetToken(user);
            }
            throw new DadosIncorretosException();
        }

        public Usuario registrar(Usuario usuario)
        {
            usuario.Validate();
            Usuario? user = usuarioRepository.FindByLogin(usuario.Login);
            if (user != null)
                throw new LoginIndisponivelException();

            return usuarioRepository.Save(usuario);
        }
    }
}
