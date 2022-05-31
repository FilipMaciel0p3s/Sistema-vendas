using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVendas.Models
{
    public class Vendas
    {
        public int Id { get; set; }

        public string Formapagamento { get; set; }

        public DateTime? DataVenda { get; set; }

        public Double ValorTotal { get; set; }

        public Cliente Clivenda { get; set; }

        public Funcionario1 funcVenda { get; set; }

        public List<VendaItem> Itens  { get; set; } = new List<VendaItem>();
    }
}