using Application.Exceptions;
using Application.Services;
using Application.Test.Fixtures;
using Domain.Entities;
using Domain.Exceptions.AreaExceptions;
using Domain.Interfaces.AreaInterfaces;
using Moq;

namespace Application.Test.Tests
{
    public class AreaServiceTest : IClassFixture<AreaFixture>
    {
        
        private readonly AreaFixture fixture;

        public AreaServiceTest(AreaFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void CadastrarArea_QuandoCodigoInvalido_DeveLancarExcecao(int codigo)
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();

            Area area = fixture.AreaValida;
            area.Codigo = codigo;


            var areaService = new AreaService(mockRepository.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => areaService.CadastrarArea(area));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("S")]
        [InlineData("SSS")]
        public void CadastrarArea_QuandoSiglaInvalida_DeveLancarExcecao(string siglaEstado)
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();

            Area area = fixture.AreaValida;
            area.SiglaEstado = siglaEstado;

            var areaService = new AreaService(mockRepository.Object);

            //WHEN & THEN
            Assert.Throws<ValidacaoException>(() => areaService.CadastrarArea(area));
        }

        [Fact]
        public void CadastrarArea_QuandoCodigoAreaJaCadastrado_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();

            Area area = fixture.AreaValida;

            mockRepository.Setup(repo => repo.FindByCodigo(area.Codigo)).Returns(area);

            var areaService = new AreaService(mockRepository.Object);

            //WHEN & THEN
            Assert.Throws<CodigoAreaCadastradoException>(() => areaService.CadastrarArea(area));
        }

        [Fact]
        public void CadastrarArea_QuandoDadosValidos_DeveRetornaNovaEntidade()
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();

            Area area = fixture.AreaValida;
            Area areaRetorno = fixture.AreaValida;
            areaRetorno.ID = 1;

            mockRepository.Setup(repo => repo.Save(area)).Returns(areaRetorno);

            var areaService = new AreaService(mockRepository.Object);

            //WHEN
            var retorno = areaService.CadastrarArea(area);

            //THEN
            Assert.Equal(retorno.ID, areaRetorno.ID);
        }

        [Fact]
        public void BuscarPorCodigoArea_QuandoAreaNaoCadastrada_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();
            var codigoArea = 11;

            var areaService = new AreaService(mockRepository.Object);

            //WHEN & THEN
            Assert.Throws<CodigoAreaNaoCadastradoException>(() => areaService.BuscarPorCodigoArea(codigoArea));
        }

        [Fact]
        public void BuscarPorCodigoArea_QuandoAreaCadastrada_DeveRetornaArea()
        {
            //GIVEN
            var mockRepository = new Mock<IAreaRepository>();
            var area = fixture.AreaValida;
            var codigoArea = 11;
            area.Codigo = codigoArea;

            mockRepository.Setup(repo=>repo.FindByCodigo(codigoArea)).Returns(area);

            var areaService = new AreaService(mockRepository.Object);

            //WHEN
            var retorno = areaService.BuscarPorCodigoArea(codigoArea);

            //THEN
            Assert.Equal(retorno.Codigo,codigoArea);
        }

    }
}