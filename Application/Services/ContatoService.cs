using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.ContatoExceptions;
using Domain.Interfaces.AreaInterfaces;
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
        private readonly IAreaService areaService;
        private readonly IMapper mapper;

        public ContatoService(IContatoRepository contatoRepository, IAreaService areaService, IMapper mapper)
        {
            this.contatoRepository = contatoRepository;
            this.areaService = areaService;
            this.mapper = mapper;
        }

        public Contato AtualizarContato(Contato contato)
        {
            var dbContato = contatoRepository.FindById(contato.ID);
            if (dbContato == null) throw new ContatoNaoEncontradoException();

            mapper.Map(contato, dbContato);
            dbContato.Validate();
            dbContato.Area = null!;

            return contatoRepository.Save(dbContato);
        }

        public Contato CadastrarContato(Contato contato)
        {
            contato.Validate();
            var dbContato = contatoRepository.FindByCodigoAreaAndTelefone(contato.CodigoArea,contato.Telefone);
            if (dbContato != null)
                throw new ContatoJaCadastradoException();

            Area area = areaService.BuscarPorCodigoArea(contato.CodigoArea);

            contatoRepository.Save(contato);
            contato.Area = area;
            return contato;
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
