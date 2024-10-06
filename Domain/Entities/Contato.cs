using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contato:EntityBase
    {
        [Required]
        public required string Nome { get; set; }
        [Required]
        [Range(10000000,999999999, ErrorMessage = "O número deve contér entre 8 e 9 dígitos.")]
        public required int Telefone { get; set; }

        public required Area Area { get; set; }
    }
}
