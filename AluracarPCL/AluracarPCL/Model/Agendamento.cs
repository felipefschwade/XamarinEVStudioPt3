using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluracarPCL.Model
{
    public class Agendamento
    {
        [JsonProperty("carro")]
        public Carro Veiculo { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        DateTime data = DateTime.Today;

        public Agendamento(Carro veiculo)
        {
            Veiculo = veiculo;
        }
        [JsonProperty("data")]
        public DateTime Data
        {
            get { return data; }
            set { this.data = value; }
        }
        public TimeSpan Hora { get; set; }
    }
}
