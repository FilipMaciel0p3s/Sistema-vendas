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
    class ClienteDAO : IDAO<Clientes>
    {
        private static Conexao conn;

        public ClienteDAO()
        {
            conn = new Conexao();
        }



        public void Delete(Clientes t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM cliente WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não removido da base de dados. Verifique e tente novamente.");

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

        public Clientes GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente " +
                                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                                                "WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var cliente = new Clientes();

                while (reader.Read())
                {
                    cliente.Id = reader.GetInt32("cod_cli");
                    cliente.Nome = reader.GetString("nome_cli");
                    cliente.CPF = reader.GetString("cpf_cli");
                    cliente.RG = reader.GetString("rg_cli");
                    cliente.DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_cli");
                    cliente.telefone = reader.GetString("telefone_fixo_cli");
                    cliente.Email = reader.GetString("email_cli");
                    cliente.Celular = reader.GetString("telefone_celular_cli");



                    if (!DAOHelper.IsNull(reader, "cod_end_fk"))
                        cliente.Endereco = new Endereco()
                        {
                            Id = reader.GetInt32("cod_end"),
                            Rua = reader.GetString("rua_end"),
                            Numero = reader.GetInt32("numero_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            Estado = reader.GetString("estado_end")
                        };
                }

                return cliente;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Clientes t)
        {
            try
            {
                var enderecoId = new EnderecoDAO().Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "INSERT INTO cliente " +
                    "(nome_cli, cpf_cli, rg_cli, datanasc_cli, telefone_fixo_cli, email_cli, telefone_celular_cli, cod_end_fk) " +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @telefone, @email, @celular, @enderecoId)";



                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);

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


        public List<Clientes> List()
        {
            try
            {
                List<Clientes> list = new List<Clientes>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente LEFT JOIN endereco ON cod_end = cod_end_fk";


                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Clientes()
                    {
                        Id = reader.GetInt32("cod_cli"),
                        Nome = DAOHelper.GetString(reader, "nome_cli"),
                        CPF = DAOHelper.GetString(reader, "cpf_cli"),
                        RG = DAOHelper.GetString(reader, "rg_cli"),
                        DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_cli"),
                        Email = DAOHelper.GetString(reader, "email_cli"),
                        telefone = DAOHelper.GetString(reader, "telefone_fixo_cli"),
                        Celular = DAOHelper.GetString(reader, "telefone_celular_cli"),
                        Endereco = DAOHelper.IsNull(reader, "cod_end_fk") ? null : new Endereco() { Id = reader.GetInt32("cod_end"), Rua = reader.GetString("rua_end"), Numero = reader.GetInt32("numero_end"), Bairro = reader.GetString("bairro_end"), Cidade = reader.GetString("cidade_end"), Estado = reader.GetString("estado_end")},
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

        public void Update(Clientes t)
        {
            try
            {
                long enderecoId = t.Endereco.Id;
                var endDAO = new EnderecoDAO();

                if (enderecoId > 0)
                    endDAO.Update(t.Endereco);
                else
                    enderecoId = endDAO.Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "UPDATE cliente SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, datanasc_cli = @datanasc, " +
                    "email_cli = @email, telefone_celular_cli = @celular, telefone_fixo_cli = @telefone" +
                    "cod_end_fk = @enderecoId WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");

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
}   }
    