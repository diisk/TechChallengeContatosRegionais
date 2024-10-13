using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AreaDtos
{
    public class CadastrarAreaRequest
    {
        public required List<NovaAreaRequest> Areas { get; set; }
    }
}
