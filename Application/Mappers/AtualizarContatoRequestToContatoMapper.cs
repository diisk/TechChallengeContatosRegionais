using Application.DTOs.ContatoDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AreaInterfaces;

namespace Application.Mappers
{
    public class AtualizarContatoRequestToContatoMapper : CustomMapper<AtualizarContatoRequest, Contato>
    {
        private readonly IAreaService areaService;

        public AtualizarContatoRequestToContatoMapper(IMapper mapper, IAreaService areaService) : base(mapper)
        {
            this.areaService = areaService;
        }

        public static void ConfigureMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AtualizarContatoRequest, Contato>()
                .ForAllMembers(config => config.Condition((src, dest, srcMember) => srcMember != null));
        }

        protected override void ApplyCustomMappings(AtualizarContatoRequest source, Contato target)
        {
            target.Area = areaService.BuscarPorCodigoArea(source.CodigoArea);
        }
    }
}
