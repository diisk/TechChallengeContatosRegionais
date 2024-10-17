using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ContatoInterfaces
{
    public interface IContatoService
    {
        List<Contato> ListarContatos(int? codigoArea = null);
        Contato CadastrarContato(Contato contato);
        Contato BuscarPorId(int id);
        Contato AtualizarContato(Contato contato);
        void ExcluirContato(int id);
    }
}
