using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.AreaExceptions;
using Domain.Interfaces.AreaInterfaces;

namespace Application.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        public Area BuscarPorCodigoArea(int codigoArea)
        {
            var area = areaRepository.FindByCodigo(codigoArea);
            if (area == null) throw new CodigoAreaNaoCadastradoException();

            return area;
        }

        public Area CadastrarArea(Area area)
        {
            area.Validate();

            if (areaRepository.FindByCodigo(area.Codigo) != null)
                throw new CodigoAreaCadastradoException();

            return areaRepository.Save(area);
        }
    }
}
