﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVendas.Models
{
   public  class Clientes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string telefone { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public Sexo Sexo { get; set; }

        public Endereco Endereco { get; set; }
    }
}
