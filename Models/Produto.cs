using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVendas.Models
{
  public  class Produto
    {
        public int Id { get; set; }

        public string Nomep { get; set; }

        public string Descricao { get; set; }

        public string Marca { get; set; }

        public Double ValorVenda { get; set; }

        private bool _selected = false;

        public bool IsSelected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
    }
}
