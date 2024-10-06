using Domain.Entities;
using Domain.Interfaces.AreaInterfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }

        public Area? FindByCodigo(int codigo)
        {
            return onlyReadDbSet.FirstOrDefault(x => x.Codigo == codigo);
        }

    }
}
