using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aula13_banco
{
    class Modalidade
    {

        private string desc;
        private float preco;
        private int qtde_alunos;
        private int qtde_aulas;
        private int ativa;

        //construtores
        public Modalidade(string desc, float preco, int qtde_alunos, int qtde_aulas)
        {
            setDesc(desc);
            setPreco(preco);
            setQtde_alunos(qtde_alunos);
            setQtde_aulas(qtde_aulas);
        }

        public Modalidade(string desc, float preco, int qtde_alunos, int qtde_aulas, int ativa)
        {
            setDesc(desc);
            setPreco(preco);
            setQtde_alunos(qtde_alunos);
            setQtde_aulas(qtde_aulas);
            setAtiva(ativa);
        }

        public Modalidade(string desc)
        {
            setDesc(desc);         
        }

        public Modalidade() {

        }


        //get and set
        public String getDesc()
        {
            return desc;
        }

        public void setDesc(String desc)
        {
            this.desc = desc;
        }

        public float getPreco()
        {
            return preco;
        }

        public void setPreco(float preco)
        {
            this.preco = preco;
        }

        public int getQtde_alunos()
        {
            return qtde_alunos;
        }

        public void setQtde_alunos(int qtde_alunos)
        {
            this.qtde_alunos = qtde_alunos;
        }

        public int getQtde_aulas()
        {
            return qtde_aulas;
        }

        public void setQtde_aulas(int qtde_aulas)
        {
            this.qtde_aulas = qtde_aulas;
        }

        public int getAtiva()
        {
            return ativa;
        }

        public void setAtiva(int ativa)
        {
            this.ativa = ativa;
        }



        //metodos
        public bool cadastrarModalidade() {
            bool ready = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand add = new MySqlCommand("insert into Estudio_modalidade (descricaoModalidade,precoModalidade," +
                    "qtdeAluno,qtdeAulas) values ('" + desc + "'," + preco + "," + qtde_alunos + "," + qtde_aulas + ")",DAO_Conexao.con);
                add.ExecuteNonQuery();
                ready = true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
            return ready;
        }



        public MySqlDataReader consultarTodasModalidades()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_modalidade", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //DAO_Conexao.con.Close();
            }
            return resultado;
        }

        public MySqlDataReader consultarModalidade() //consulta somente a modalidade desejada
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_modalidade where descricaoModalidade='" + desc + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //DAO_Conexao.con.Close();
            }
            return resultado;
        }


        
        public bool atualizarModalidade(int cod)
        {
            bool ready = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand add = new MySqlCommand("update Estudio_modalidade set descricaoModalidade='"+desc+ "', precoModalidade="+preco+"," +
                    "qtdeAluno="+qtde_alunos+ ", qtdeAulas="+qtde_aulas+ ", ativa="+ativa+" where idEstudio_Modalidade="+cod, DAO_Conexao.con);
                add.ExecuteNonQuery();
                ready = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return ready;
        }

        
        public bool excluirModalidade(int id)
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_modalidade set ativa = 1 where idEstudio_Modalidade = '" + id + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc;
        }
    }
}
