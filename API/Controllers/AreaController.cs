using Application.DTOs;
using Application.DTOs.AreaDtos;
using Application.DTOs.Auth;
using Application.DTOs.AuthDtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AreaInterfaces;
using Domain.Interfaces.UsuarioInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/areas")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IResponseService responseService;
        private readonly IAreaService areaService;

        public AreaController(IMapper mapper, IResponseService responseService, IAreaService areaService)
        {
            this.mapper = mapper;
            this.responseService = responseService;
            this.areaService = areaService;
        }

        [HttpPost]
        public ActionResult<BaseResponse<List<AreaResponse>>> login([FromBody] CadastrarAreaRequest request)
        {
            var areas = mapper.Map<List<Area>>(request.Areas);
            var retorno = areaService.CadastrarAreas(areas);
            var response = mapper.Map<List<AreaResponse>>(retorno);
            return responseService.Ok(response);
        }
    }
}
