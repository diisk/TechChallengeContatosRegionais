using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidacaoException : ApiException
    {
        public ValidacaoException(string mensagem) : base(HttpStatusCode.BadRequest, mensagem) { }

    }
}
