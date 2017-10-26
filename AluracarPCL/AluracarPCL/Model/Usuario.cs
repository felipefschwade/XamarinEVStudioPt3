using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluracarPCL.Model
{
    public class Usuario
    {
        public Usuario()
        {
        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        [JsonProperty("dataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
