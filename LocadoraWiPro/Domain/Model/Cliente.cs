using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Cliente
    {
        public Cliente()
        {
            Inativo = false;
        }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Inativo { get; set; }
    }
}
