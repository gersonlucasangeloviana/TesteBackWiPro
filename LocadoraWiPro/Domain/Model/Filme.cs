using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
   public class Filme
    {
        public Filme()
        {
            Alugado = false;
            Inativo = false;
        }
        public int FilmeId { get; set; }
        public string CodigoEan { get; set; }
        public string Nome { get; set; }
        public bool Alugado { get; set; }
        public bool Inativo { get; set; }
    }
}
