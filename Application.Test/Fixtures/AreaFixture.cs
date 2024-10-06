using Domain.Entities;
using Domain.Enums.AreaEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Fixtures
{
    public class AreaFixture
    {
        public Area AreaValida
        {
            get
            {
                return new Area
                {
                    Codigo = 31,
                    Regiao = RegiaoBrasil.SUDESTE,
                    SiglaEstado = "MG",
                    Cidades = "Belo Horizonte;Contagem;Betim;Nova Lima",
                    Descricao = "Teste"
                };
            }
        }

    }
}
