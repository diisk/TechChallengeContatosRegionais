using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ConteudoDiferenteException : ApiException
    {
        public ConteudoDiferenteException() : base(HttpStatusCode.BadRequest, "Conteudo do corpo está diferente do esperado.") { }

    }
}
