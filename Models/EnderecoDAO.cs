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
    class EnderecoDAO
    {
        private static Conexao conn = new Conexao();
        public long Insert(Endereco t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO endereco (rua_end, numero_end, bairro_end, cidade_end, estado_end) " +
                    "VALUES (@rua, @numero, @bairro, @cidade, @estado)";

                query.Parameters.AddWithValue("@rua", t.Rua);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@estado", t.Estado);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao salvar o endereço. Verifique e tente novamente.");

                return query.LastInsertedId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Endereco t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE endereco SET rua_end = @rua, numero_end = @numero, bairro_end = @bairro, " +
                            "cidade_end = @cidade, estado_end = @estado WHERE cod_end = @id ";

                query.Parameters.AddWithValue("@rua", t.Rua);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@estado", t.Estado);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao atualizar o endereço. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static List<Endereco> List()
        {
            try
            {
                List<Endereco> list = new List<Endereco>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM endereco";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Endereco()
                    {
                        Id = reader.GetInt32("cod_end"),
                        Rua = reader.GetString("rua_end"),
                        Bairro = reader.GetString("bairro_end"),
                        Estado = reader.GetString("estado_end"),
                        Numero = reader.GetInt32("numero_end"),
                        Cidade = reader.GetString("cidade_end")

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
    }
}
