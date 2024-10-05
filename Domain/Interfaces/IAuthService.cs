using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthService
    {
        string logar(string email, string senha);
        Usuario registrar(string email, string senha);
    }
}
