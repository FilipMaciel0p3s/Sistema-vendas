using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemadeVendas.DataBase;
using SistemadeVendas.Interface;
using SistemadeVendas.Helper;
using MySql.Data.MySqlClient;

namespace SistemadeVendas.Models
{
    class ProdutoDAO : IDAO<Produto>
    {
        private Conexao conn;

        public ProdutoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Produto t)
        {
            throw new NotImplementedException();
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produto t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO produto " +
                    "(nome_prod, descricao_prod, marca_prod, valor_venda_prod)" +
                  " VALUES (@nome, @descricao, @marca, @valor)";



                query.Parameters.AddWithValue("@nome", t.Nomep);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@valor", t.ValorVenda);
      

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
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

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("cod_prod"),
                        Nomep = DAOHelper.GetString(reader, "nome_prod"),
                        Marca = DAOHelper.GetString(reader, "marca_prod"),
                        Descricao = DAOHelper.GetString(reader, "descricao_prod"),
                        ValorVenda = DAOHelper.GetDouble(reader, "valor_venda_prod")
                    });
                }

                return list;
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

        public void Update(Produto t)
        {
            throw new NotImplementedException();
        }
    }
}
