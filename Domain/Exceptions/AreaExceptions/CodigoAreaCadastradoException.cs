using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.AreaExceptions
{
    public class CodigoAreaCadastradoException : ApiException
    {
        public CodigoAreaCadastradoException() : base(HttpStatusCode.Conflict, "Esse código de área já está cadastrado.")
        {
        }
    }
}
