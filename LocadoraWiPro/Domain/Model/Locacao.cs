using System;
using System.Text.Json.Serialization;

namespace Domain.Model
{
   public class Locacao
    {
        public Locacao()
        {
            Devolvido = false;
        }
        public int LocacaoId { get; set; }
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int FilmeId { get; set; }
        [JsonIgnore]
        public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Devolvido { get; set; }
        public string Observacao { get; set; }
    }
}
