using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public abstract class ApiException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public ApiException(HttpStatusCode status, string mensagem) : base(mensagem)
        {
            Status = status;
        }
    }
}
