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
   public class SexoDAO : IDAO<Sexo>
    {
        private static Conexao conn;

        public SexoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Sexo t)
        {
            throw new NotImplementedException();
        }

        public Sexo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Sexo t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO sexo " +
                    "(cod_sex) " +
                    "VALUES (@sexoid)";



                query.Parameters.AddWithValue("@sexoid", t.Id);

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

        public List<Sexo> List()
        {
            try
            {
                List<Sexo> list = new List<Sexo>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM sexo";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Sexo()
                    {
                        Id = reader.GetInt32("cod_sex"),
                        Genero = reader.GetString("nome_sex")
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

        public void Update(Sexo t)
        {
            throw new NotImplementedException();
        }
    }
}