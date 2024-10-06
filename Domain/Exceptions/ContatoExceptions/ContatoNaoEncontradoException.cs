using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ContatoExceptions
{
    public class ContatoNaoEncontradoException : ApiException
    {
        public ContatoNaoEncontradoException() : base(HttpStatusCode.NotFound, "Contato não encontrado.")
        {
        }
    }
}
