using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemadeVendas.DataBase;
using MySql.Data.MySqlClient;

namespace SistemadeVendas.Models
{
   public class VendaItem
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public Double Valor { get; set; }

        public Double ValorTotal { get; set; }

        public string telefone { get; set; }

        public Vendas vendas { get; set; }
        public Produto provend { get; set; }

      


    }
}
