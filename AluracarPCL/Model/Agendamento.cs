using System;
using System.Collections.Generic;
using System.Text;

namespace Aluracar.Model
{
    public class Agendamento
    {
        public Carro Veiculo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        DateTime data = DateTime.Today;

        public Agendamento(Carro veiculo)
        {
            Veiculo = veiculo;
        }

        public DateTime Data
        {
            get { return data; }
            set { this.data = value; }
        }
        public TimeSpan Hora { get; set; }
    }
}
