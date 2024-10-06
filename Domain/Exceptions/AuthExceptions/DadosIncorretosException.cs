using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.AuthExceptions
{
    public class DadosIncorretosException : ApiException
    {
        public DadosIncorretosException() : base(HttpStatusCode.Unauthorized, "Dados incorretos.") { }
    }
}
