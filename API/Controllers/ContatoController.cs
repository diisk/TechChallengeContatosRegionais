using Application.DTOs;
using Application.DTOs.AreaDtos;
using Application.DTOs.Auth;
using Application.DTOs.AuthDtos;
using Application.DTOs.ContatoDtos;
using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AreaInterfaces;
using Domain.Interfaces.ContatoInterfaces;
using Domain.Interfaces.UsuarioInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IResponseService responseService;
        private readonly IContatoService contatoService;

        public ContatoController(IMapper mapper, IResponseService responseService, IContatoService contatoService)
        {
            this.mapper = mapper;
            this.responseService = responseService;
            this.contatoService = contatoService;
        }

        [HttpPost]
        public ActionResult<BaseResponse<ContatoResponse>> CadastrarContato([FromBody] CadastrarContatoRequest request)
        {
            var contato = mapper.Map<Contato>(request);
            var retorno = contatoService.CadastrarContato(contato);
            var response = mapper.Map<ContatoResponse>(retorno);
            return responseService.Ok(response);
        }

        [HttpGet]
        public ActionResult<BaseResponse<ListarContatoResponse>> ListarContatos([FromQuery] int? codigoArea)
        {
            var retorno = contatoService.ListarContatos(codigoArea);
            var response = new ListarContatoResponse
            {
                TotalResultados = retorno.Count,
                Resultados = mapper.Map<List<ContatoResponse>>(retorno)
            };
            return responseService.Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<BaseResponse<Object>> ExcluirContato([FromRoute] int id)
        {
            contatoService.ExcluirContato(id);
            return responseService.Ok<Object>();
        }

        [HttpPost("{id}")]
        public ActionResult<BaseResponse<ContatoResponse>> EditarContato([FromRoute] int id, [FromBody] AtualizarContatoRequest request)
        {
            var contato = mapper.Map<Contato>(request);
            contato.ID = id;
            var retorno = contatoService.AtualizarContato(contato);
            var response = mapper.Map<ContatoResponse>(retorno);
            return responseService.Ok<ContatoResponse>();
        }
    }
}
