using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.AreaInterfaces
{
    public interface IAreaService
    {
        List<Area> CadastrarAreas(List<Area> areas);
        Area BuscarPorCodigoArea(int codigoArea);
    }
}
