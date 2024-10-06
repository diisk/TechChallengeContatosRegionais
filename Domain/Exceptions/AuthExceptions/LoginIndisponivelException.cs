using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.AuthExceptions
{
    public class LoginIndisponivelException : ApiException
    {
        public LoginIndisponivelException() : base(HttpStatusCode.Conflict, "Esse login já está em uso.") { }
    }
}
