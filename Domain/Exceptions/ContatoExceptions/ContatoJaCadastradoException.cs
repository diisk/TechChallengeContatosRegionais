using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ContatoExceptions
{
    public class ContatoJaCadastradoException : ApiException
    {
        public ContatoJaCadastradoException() : base(HttpStatusCode.Conflict, "Já existe um contato cadastrado com esse telefone e código de área.")
        {
        }
    }
}
