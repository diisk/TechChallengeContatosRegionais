using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Contatos")]
    public class Contato:EntityBase
    {
        [Required]
        public required string Nome { get; set; }
        [Required]
        [Range(10000000,999999999, ErrorMessage = "O número deve contér entre 8 e 9 dígitos.")]
        public required int Telefone { get; set; }
        
        public int AreaId { get; set; }
        public required virtual Area Area { get; set; }
    }
}
