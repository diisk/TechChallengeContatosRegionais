using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ContatoDtos
{
    public class AtualizarContatoRequest
    {
        public string? Nome { get; set; }
        public int Telefone { get; set; } = 0;
        public int CodigoArea { get; set; } = 0;
    }
}
