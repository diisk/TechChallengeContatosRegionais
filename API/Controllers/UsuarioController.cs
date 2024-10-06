using Application.DTOs;
using Application.DTOs.Auth;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UsuarioInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IAuthService authService;
        private readonly IMapper mapper;
        private readonly IResponseService responseService;
        private readonly ICryptoService cryptoService;

        public UsuarioController(IAuthService authService, IMapper mapper, IResponseService responseService, ICryptoService cryptoService)
        {
            this.authService = authService;
            this.mapper = mapper;
            this.responseService = responseService;
            this.cryptoService = cryptoService;
        }

        [HttpPost("logar")]
        [AllowAnonymous]
        public ActionResult<BaseResponse<LogarResponse>> login([FromBody] LogarRequest request)

        {
            var token = authService.logar(request.Login, request.Senha);
            return responseService.Ok(new LogarResponse { Token = token });
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public ActionResult<BaseResponse<string>> registrar([FromBody] RegistrarRequest request)
        {
            var usuario = mapper.Map<Usuario>(request);
            usuario.SenhaHasheada = cryptoService.HashearSenha(request.Senha);
            authService.registrar(usuario);
            return responseService.NoContent<string>();
        }
    }
}
