using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluracarPCL.Model
{
    public class Carro
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("preco")]
        public decimal Valor { get; set; }
        public string PrecoFormatado
        {
            get
            {
                return String.Format("R$ {0}", Valor);
            }
        }
        public int ABS = 800;
        public int AR_COND = 1000;
        public int MP3 = 500;
        public bool TemAbs { get; set; }
        public bool TemAr { get; set; }
        public bool TemMp3 { get; set; }
        public string ValorTotalFormatado
        {
            get
            {
                return String.Format("Valor Total R$ {0}",
                Valor + (TemAbs ? ABS : 0)
                + (TemAr ? AR_COND : 0)
                + (TemMp3 ? MP3 : 0)
                );
            }
        }

    }
}
