using Application.Services;
using Application.Test.Fixtures;
using Domain.Entities;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Application.Test.Tests
{
    public class ClienteServiceTest : IClassFixture<ClienteFixture>
    {
        //EXEMPLO
        //private readonly ClienteFixture fixture;

        //public ClienteServiceTest(ClienteFixture fixture)
        //{
        //    this.fixture = fixture;
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData("asdfasdf")]
        //[InlineData("000.000.000-00")]
        //public void CadastrarCliente_QuandoCpfInvalido_DeveLancarExcecao(string cpf)
        //{
        //    //GIVEN
        //    var mockRepository = new Mock<IClienteRepository>();

        //    Cliente cliente = fixture.ClienteValido;
        //    cliente.Cpf = cpf;

        //    //mockRepository.Setup(repo => repo.Save(cliente))
        //    //    .Returns(r =>r);
        //    var clienteService = new ClienteService(mockRepository.Object);

        //    //WHEN & THEN
        //    var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));
        //    var errors = new string[]{ "Cpf obrigatório", "O cpf deve conter 11 digitos" };
        //    Assert.Contains(errors, e => exception.Message.Contains(e));
        //}

        //[Fact]
        //public void CadastrarCliente_QuandoNomeEmBranco_DeveLancarExcecao()
        //{
        //    //GIVEN
        //    var mockRepository = new Mock<IClienteRepository>();

        //    Cliente cliente = fixture.ClienteValido;
        //    cliente.NomeCompleto = "";

        //    var clienteService = new ClienteService(mockRepository.Object);

        //    //WHEN & THEN
        //    var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));
        //    var errors = new List<string>() { "Nome completo obrigatório" };
        //    Assert.Contains(errors, e => exception.Message.Contains(e));


        //}

        //[Fact]
        //public void CadastrarCliente_QuandoDadosInvalidos_DeveLancarExcecao()
        //{
        //    //GIVEN
        //    var mockRepository = new Mock<IClienteRepository>();

        //    Cliente cliente = createBlankCliente();

        //    //mockRepository.Setup(repo => repo.Save(cliente))
        //    //    .Returns(r =>r);
        //    var clienteService = new ClienteService(mockRepository.Object);

        //    //WHEN & THEN
        //    Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));

        //}
    }
}