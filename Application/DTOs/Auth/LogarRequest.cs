namespace Application.DTOs.Auth
{
    public class LogarRequest
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}