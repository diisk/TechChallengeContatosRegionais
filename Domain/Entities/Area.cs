using Domain.Enums.AreaEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Area : EntityBase
    {
        [Range(10,99, ErrorMessage = "O código de área deve conter 2 números")]
        public required int Codigo { get; set; }
        public required RegiaoBrasil Regiao {  get; set; }

        [Required]
        [Length(2,2,ErrorMessage = "A sigla deve conter 2 letras.")]
        public required string SiglaEstado { get; set; }

        public string? Cidades { get; set; }

        public string? Descricao { get; set; }
    }
}
