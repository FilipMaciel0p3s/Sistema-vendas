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
    class FuncionarioDAO : IDAO<Funcionario1>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Funcionario1 t)
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionario1 t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Funcionario1 t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM funcionario WHERE cod_func = @id";

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

        public Funcionario1 GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario " +
                                                "LEFT JOIN sexo ON cod_sex = cod_sex_fk " +
                                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                                                "WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var funcionario = new Funcionario1();

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("cod_func");
                    funcionario.Nome = reader.GetString("nome_func");
                    funcionario.CPF = reader.GetString("cpf_func");
                    funcionario.RG = reader.GetString("rg_func");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Celular = reader.GetString("celular_func");
                    funcionario.Funcao = reader.GetString("funcao_func");
                    funcionario.Salario = DAOHelper.GetDouble(reader, "salario_func");

                    if (!DAOHelper.IsNull(reader, "cod_sex_fk"))
                        funcionario.Sexo = new Sexo()
                        {
                            Id = reader.GetInt32("cod_sex"),
                            Genero = reader.GetString("nome_sex")
                        };

                    if (!DAOHelper.IsNull(reader, "cod_end_fk"))
                        funcionario.Endereco = new Endereco()
                        {
                            Id = reader.GetInt32("cod_end"),
                            Rua = reader.GetString("rua_end"),
                            Numero = reader.GetInt32("numero_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            Estado = reader.GetString("estado_end")
                        };
                }

                return funcionario;
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

        public List<Funcionario1> List()
        {
            try
            {
                List<Funcionario1> list = new List<Funcionario1>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";


                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario1()
                    {
                        Id = reader.GetInt32("cod_func"),
                        Nome = DAOHelper.GetString(reader, "nome_func"),
                        CPF = DAOHelper.GetString(reader, "cpf_func"),
                        RG = DAOHelper.GetString(reader, "rg_func"),
                        DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func"),
                        Email = DAOHelper.GetString(reader, "email_func"),
                        Celular = DAOHelper.GetString(reader, "celular_func"),
                        Funcao = DAOHelper.GetString(reader, "funcao_func"),
                        Salario = DAOHelper.GetDouble(reader, "salario_func"),
                        Sexo = DAOHelper.IsNull(reader, "cod_sex_fk") ? null : new Sexo() { Id = reader.GetInt32("cod_sex"), Genero = reader.GetString("nome_sex") },
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
