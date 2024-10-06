using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.AreaExceptions
{
    public class CodigoAreaNaoCadastradoException : ApiException
    {
        public CodigoAreaNaoCadastradoException() : base(HttpStatusCode.NotFound, "Esse código de área não está cadastrado ou não existe.")
        {
        }
    }
}
