using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemadeVendas.DataBase;
using SistemadeVendas.Interface;
using SistemadeVendas.Helper;

namespace SistemadeVendas.Models
{
    class VendaDAO : IDAO<Vendas>
    {
        private Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Vendas t)
        {
            throw new NotImplementedException();
        }

        public Vendas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vendas t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO venda (cod_func_fk, cod_cli_fk, data_vend, forma_pagamento_vend, valor_total_vend) " +
                                                        "VALUES (@funcionario, @cliente, @data, @forma_pagamento, @valor_total)";

                query.Parameters.AddWithValue("@funcionario", t.funcVenda.Id);
                query.Parameters.AddWithValue("@cliente", t.Clivenda);
                query.Parameters.AddWithValue("@data", t.DataVenda?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@forma_pagamento", t.Formapagamento);
                query.Parameters.AddWithValue("@valor_total", t.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("A venda não foi realizada. Verifique e tente novamente.");

                long VendaId = query.LastInsertedId;

               InsertItens(VendaId, t.Itens);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        private void InsertItens(long vendaId, List<VendaItem> itens)
        {
                foreach (VendaItem provend in itens)
                {
                    var query = conn.Query();
                    query.CommandText = "INSERT INTO venda_itens (cod_vend_fk, cod_prod_fk, quantidade_itenv, valor_itenv, valor_total_itenv) " +
                        "VALUES (@venda, @produto, @quantidade, @valor, @valor_total)";

                    query.Parameters.AddWithValue("@venda", vendaId);
                    query.Parameters.AddWithValue("@produto", provend.provend.Id);
                    query.Parameters.AddWithValue("@quantidade", provend.Quantidade);
                    query.Parameters.AddWithValue("@valor", provend.Valor);
                    query.Parameters.AddWithValue("@valor_total", provend.ValorTotal);

                    var result = query.ExecuteNonQuery();

                    if (result == 0)
                        throw new Exception("Os itens da venda não foi adicionada. Verifique e tente novamente.");
                }
           

        }

        public List<Vendas> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Vendas t)
        {
            throw new NotImplementedException();
        }
    }
}

