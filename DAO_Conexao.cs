using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aula13_banco
{
    class DAO_Conexao
    {
        public static MySqlConnection con; 

        public static Boolean getConexao(String local, String banco, string user, String senha)
        {
            Boolean retorno = false; 
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";" + "database=" + banco + "; password=" + senha + "; SslMode = none");
                retorno = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        public static Boolean CadLogin(string usuario, string senha, int tipo) {
            bool cad = false;
            try {
                con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_usuario (usuario,senha,tipo)" + "values('" + usuario + "','" + senha + "'," + tipo + ")", con);
                insere.ExecuteNonQuery();
                cad = true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally {
                con.Close();
            }
            return cad;
        }
        public static int VerificaLogin(string usuario, string senha)
        {
            int tipo = 0;
            try
            {
                con.Open();
                MySqlCommand seleciona = new MySqlCommand("select * from Estudio_usuario where usuario='" + usuario +"' and senha='" + senha + "'", con);
                MySqlDataReader result = seleciona.ExecuteReader();
                if (result.Read()) {
                    tipo = Convert.ToInt32(result["tipo"].ToString()); 

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
                Console.WriteLine(tipo.ToString());
            }
            return tipo;
        }


    }

}
