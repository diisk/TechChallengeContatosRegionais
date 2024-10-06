using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Usuario")]
    public class Usuario:EntityBase
    {

        [Required]
        public required string Login { get; set; }
        [Required]
        public required string SenhaHasheada { get; set; }

    }
}
