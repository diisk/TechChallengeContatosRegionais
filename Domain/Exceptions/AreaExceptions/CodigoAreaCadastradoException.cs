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
        public CodigoAreaCadastradoException(List<int> codigos) : base(
            HttpStatusCode.Conflict,
            "Os seguintes códigos de área já estão cadastrados: " + CodigosToString(codigos))
        {
        }

        private static string CodigosToString(List<int> codigos)
        {
            return string.Join(',', codigos.Select(c => c.ToString()));
        }
    }
}
