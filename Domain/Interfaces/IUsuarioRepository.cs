using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? FindByEmail(string email);
    }
}
