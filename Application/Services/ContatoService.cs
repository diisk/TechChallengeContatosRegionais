using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.ContatoExceptions;
using Domain.Interfaces.ContatoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository contatoRepository;
        private readonly IMapper mapper;
        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            this.contatoRepository = contatoRepository;
            this.mapper = mapper;
        }

        public Contato AtualizarContato(Contato contato)
        {
            contato.Validate();

            var dbContato = contatoRepository.FindById(contato.ID);
            if (dbContato == null) throw new ContatoNaoEncontradoException();

            mapper.Map(contato, dbContato);

            return contatoRepository.Save(dbContato);
        }

        public Contato CadastrarContato(Contato contato)
        {
            contato.Validate();
            var dbContato = contatoRepository.FindByTelefone(contato.Telefone);
            if (dbContato != null && dbContato.Area.Codigo == contato.Area.Codigo)
                throw new ContatoJaCadastradoException();

            return contatoRepository.Save(contato);

        }

        public void ExcluirContato(int id)
        {
            var contato = contatoRepository.FindById(id);
            if (contato != null)
            {
                contato.Remove();
                contatoRepository.Save(contato);
            }
            
        }

        public List<Contato> ListarContatos(int? codigoArea = null)
        {
            if (codigoArea == null) return contatoRepository.FindAll().ToList();

            return contatoRepository.FindByCodigoArea(codigoArea.Value);
        }
    }
}
