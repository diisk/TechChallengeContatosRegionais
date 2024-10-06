using Domain.Entities;

namespace Domain.Interfaces.ContatoInterfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Contato? FindByTelefone(int telefone);
        List<Contato> FindByCodigoArea(int codigoArea);
    }
}
