using Application.Exceptions;
using Application.Services;
using Application.Test.Fixtures;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.AreaExceptions;
using Domain.Exceptions.ContatoExceptions;
using Domain.Interfaces.AreaInterfaces;
using Domain.Interfaces.ContatoInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Tests
{
    public class ContatoServiceTest : IClassFixture<ContatoFixture>, IClassFixture<AreaFixture>
    {
        private readonly ContatoFixture fixture;
        private readonly AreaFixture areaFixture;

        public ContatoServiceTest(ContatoFixture fixture, AreaFixture areaFixture)
        {
            this.fixture = fixture;
            this.areaFixture = areaFixture;
        }

        [Fact]
        public void AtualizarContato_QuandoContatoNaoEncontrado_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ContatoNaoEncontradoException>(() => contatoService.AtualizarContato(contato));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AtualizarContato_QuandoNomeInvalido_DeveLancarExcecao(string nome)
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contatoRetorno = fixture.ContatoValido;
            var contato = fixture.ContatoValido;
            contato.Nome = nome;

            mockRepository.Setup(repo => repo.FindById(contato.ID)).Returns(contatoRetorno);
            mockMapper.Setup(mapper => mapper.Map(contato, contatoRetorno)).Callback(() =>
            {
                contatoRetorno.Nome = contato.Nome;
            });

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => contatoService.AtualizarContato(contato));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000000)]
        [InlineData(1000000000)]
        public void AtualizarContato_QuandoTelefoneInvalido_DeveLancarExcecao(int telefone)
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contatoRetorno = fixture.ContatoValido;
            var contato = fixture.ContatoValido;
            contato.Telefone = telefone;

            mockRepository.Setup(repo => repo.FindById(contato.ID)).Returns(contatoRetorno);
            mockMapper.Setup(mapper => mapper.Map(contato, contatoRetorno)).Callback(() =>
            {
                contatoRetorno.Telefone = contato.Telefone;
            });

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => contatoService.AtualizarContato(contato));
        }

        [Fact]
        public void AtualizarContato_QuandoDadosCorretos_DeveRetornarEntidadeAtualizada()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contatoEncontrado = fixture.ContatoValido;
            var contato = fixture.ContatoValido;
            contato.Telefone = 70707070;
            contato.Nome = "Maria Teste da Silva";

            mockRepository.Setup(repo => repo.FindById(contato.ID)).Returns(contatoEncontrado);
            mockMapper.Setup(mapper => mapper.Map(contato, contatoEncontrado)).Callback(() =>
            {
                contatoEncontrado.Telefone = contato.Telefone;
                contatoEncontrado.Nome = contato.Nome;
            });
            mockRepository.Setup(repo => repo.Save(contatoEncontrado)).Returns(contatoEncontrado);

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN
            var retorno = contatoService.AtualizarContato(contato);

            //THEN
            Assert.Equal(retorno.Telefone, contato.Telefone);
            Assert.Equal(retorno.Nome, contato.Nome);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CadastrarContato_QuandoNomeInvalido_DeveLancarExcecao(string nome)
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;
            contato.Nome = nome;

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => contatoService.CadastrarContato(contato));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000000)]
        [InlineData(1000000000)]
        public void CadastrarContato_QuandoTelefoneInvalido_DeveLancarExcecao(int telefone)
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;
            contato.Telefone = telefone;

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => contatoService.CadastrarContato(contato));
        }

        [Fact]
        public void CadastrarContato_QuandoContatoJaCadastrado_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;

            mockRepository.Setup(repo => repo.FindByCodigoAreaAndTelefone(contato.CodigoArea,contato.Telefone)).Returns(contato);

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<ContatoJaCadastradoException>(() => contatoService.CadastrarContato(contato));
        }

        [Fact]
        public void CadastrarContato_QuandoAreaNaoEncontrada_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;

            mockAreaService.Setup(service => service.BuscarPorCodigoArea(contato.CodigoArea)).Throws<CodigoAreaNaoCadastradoException>();

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN & THEN
            Assert.Throws<CodigoAreaNaoCadastradoException>(() => contatoService.CadastrarContato(contato));
        }

        [Fact]
        public void CadastrarContato_QuandoDadosCorretos_DeveRetornarEntidadeComID()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;
            var area = areaFixture.AreaValida;
            var contatoRetorno = fixture.ContatoValido;

            area.Codigo = 31;
            contato.CodigoArea = area.Codigo;
            contatoRetorno.ID = 1;

            mockRepository.Setup(repo => repo.Save(contato)).Callback(() => {
                contato.ID = 1;
            });
            mockAreaService.Setup(service => service.BuscarPorCodigoArea(contato.CodigoArea)).Returns(area);

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN
            var retorno = contatoService.CadastrarContato(contato);

            //THEN
            Assert.Equal(retorno.ID, contatoRetorno.ID);
            Assert.Equal(retorno.Area, area);
        }

        [Fact]
        public void ExcluirContato_QuandoDadosCorretos_DeveMudarEntidadeParaInativa()
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var contato = fixture.ContatoValido;
            var contatoSalvo = false;

            mockRepository.Setup(repo => repo.FindById(contato.ID)).Returns(contato);
            mockRepository.Setup(repo => repo.Save(contato)).Callback(() =>
            {
                contatoSalvo = true;
            });

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN
            contatoService.ExcluirContato(contato.ID);

            //THEN
            Assert.True(contatoSalvo);
            Assert.True(contato.Removed);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(31)]
        [InlineData(1)]
        public void ListarContatos_QuandoFuncional_DeveRetornarListaDeContatos(int? codigoArea)
        {
            //GIVEN
            var mockRepository = new Mock<IContatoRepository>();
            var mockAreaService = new Mock<IAreaService>();
            var mockMapper = new Mock<IMapper>();

            var listaContatos = fixture.ListaContatosValidos;
            var listaFiltrada = new List<Contato>();

            listaFiltrada.AddRange(listaContatos);

            if (codigoArea.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(cont => cont.Area.Codigo == codigoArea).ToList();
                mockRepository.Setup(repo => repo.FindByCodigoArea(codigoArea.Value)).Returns(listaFiltrada);
            }

            mockRepository.Setup(repo => repo.FindAll()).Returns(listaContatos);

            var contatoService = new ContatoService(mockRepository.Object, mockAreaService.Object, mockMapper.Object);

            //WHEN
            var retorno = contatoService.ListarContatos(codigoArea);

            //THEN
            Assert.Equal(retorno, listaFiltrada);
        }
    }
}
