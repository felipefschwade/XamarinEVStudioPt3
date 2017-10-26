using System;
using System.Collections.Generic;
using System.Text;

namespace AluracarPCL.Model
{
    public class ListagemVeiculos
    {
        public ListagemVeiculos()
        {
            Veiculos = new List<Carro>()
            {
                new Carro { Nome = "Azera", Valor = 58000 },
                new Carro { Nome = "Fiesta 2.0", Valor = 40000 },
                new Carro { Nome = "S10 Flex", Valor = 30000 }
            };
        }

        public List<Carro> Veiculos { get; private set; }
    }
}
