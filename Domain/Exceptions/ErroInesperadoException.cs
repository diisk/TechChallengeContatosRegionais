using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ErroInesperadoException : ApiException
    {
        public ErroInesperadoException(string message) : base(HttpStatusCode.InternalServerError, message) { }

    }
}
