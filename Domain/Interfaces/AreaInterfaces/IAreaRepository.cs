using Domain.Entities;

namespace Domain.Interfaces.AreaInterfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        Area? FindByCodigo(int codigo);
    }
}
