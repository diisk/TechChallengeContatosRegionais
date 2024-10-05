using Application.DTOs;
using Application.DTOs.Auth;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
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

        public UsuarioController(IAuthService authService, IMapper mapper, IResponseService responseService)
        {
            this.authService = authService;
            this.mapper = mapper;
            this.responseService = responseService;
        }

        [HttpPost("logar")]
        [AllowAnonymous]
        public ActionResult<BaseResponse<string>> login([FromBody] LogarRequest request)

        {
            var token = authService.logar(request.Email, request.Senha);
            return responseService.Ok(token);
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public ActionResult<BaseResponse<string>> registrar([FromBody] RegistrarRequest request)
        {
            authService.registrar(request.Email,request.Senha);
            return responseService.NoContent<string>();
        }
    }
}
