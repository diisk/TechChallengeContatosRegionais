using Domain.Enums.AreaEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AreaDtos
{
    public class AreaResponse
    {
        public required int Codigo { get; set; }
        public required RegiaoBrasil Regiao { get; set; }

        public required string SiglaEstado { get; set; }

        public string? Cidades { get; set; }

        public string? Descricao { get; set; }
    }
}
