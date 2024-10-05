using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Usuario")]
    public class Usuario:EntityBase
    {

        [EmailAddress]
        public required string Email { get; set; }
        public required string SenhaHasheada { get; set; }

    }
}
