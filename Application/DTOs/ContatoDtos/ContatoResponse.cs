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
    public class ContatoResponse
    {
        public int ID { get; set; }
        public required string Nome { get; set; }
        public required int Telefone { get; set; }
        public required AreaResponse Area { get; set; }
    }
}
