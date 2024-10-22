namespace Application.DTOs.ContatoDtos
{
    public class CadastrarContatoRequest
    {
        public required string Nome { get; set; }
        public required int Telefone { get; set; }
        public int CodigoArea { get; set; }
    }
}
