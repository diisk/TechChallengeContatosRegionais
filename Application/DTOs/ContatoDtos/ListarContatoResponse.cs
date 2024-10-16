using Application.DTOs.AreaDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ContatoDtos
{
    public class ListarContatoResponse
    {
        public int TotalResultados {  get; set; }
        public required List<ContatoResponse> Resultados { get; set; }
    }
}
