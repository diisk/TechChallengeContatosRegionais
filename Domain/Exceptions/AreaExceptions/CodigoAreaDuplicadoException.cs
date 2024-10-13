using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.AreaExceptions
{
    public class CodigoAreaDuplicadoException : ApiException
    {
        public CodigoAreaDuplicadoException() : base(
            HttpStatusCode.Conflict,
            "Existem códigos de área duplicados na lista fornecida.")
        {
        }
    }
}
