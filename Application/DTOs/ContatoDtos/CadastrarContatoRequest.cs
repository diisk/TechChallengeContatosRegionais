using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ContatoDtos
{
    public class CadastrarContatoRequest
    {
        public required string Nome { get; set; }
        public required int Telefone { get; set; }
        public int CodigoArea { get; set; }
    }
}
