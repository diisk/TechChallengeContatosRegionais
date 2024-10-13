using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Fixtures
{
    public class UsuarioFixture
    {
        public Usuario UsuarioValido
        {
            get
            {
                return new Usuario
                {
                    Login = "teste",
                    Senha = "senha"
                };
            }
        }
    }
}
