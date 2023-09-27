using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aula13_banco
{
    public partial class ConsultarModalidade : Form
    {
        public ConsultarModalidade()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarTodasModalidades();
            while (le.Read())
            {
                comboBox1.Items.Add(le["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((comboBox1.Text!="") && (txtPreco.Text !="") && (txtAluno.Text!="") && (txtAula.Text!=""))
            {
                int ativo=0;
                if (checkBox1.Checked == false)
                {
                    ativo = 0;
                }
                else
                {
                    ativo = 1;
                }
                Modalidade m = new Modalidade(comboBox1.Text, float.Parse(txtPreco.Text), int.Parse(txtAluno.Text), int.Parse(txtAula.Text),ativo);
                if (m.atualizarModalidade(int.Parse(cod)))
                {
                    MessageBox.Show("Atualizado!");
                    checkBox1.Checked = false;
                    txtPreco.Text = "";
                    txtAluno.Text = "";
                    txtAula.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    Modalidade m2 = new Modalidade();
                    MySqlDataReader le2 = m2.consultarTodasModalidades();
                    while (le2.Read())
                    {
                            comboBox1.Items.Add(le2["descricaoModalidade"].ToString());
                    }
                    DAO_Conexao.con.Close();
                }
            }
            else
            {
                MessageBox.Show("Insira os dados!");
            }
        }

        string cod;
        private void button2_Click(object sender, EventArgs e)
        {
            Modalidade m = new Modalidade(comboBox1.Text);
            MySqlDataReader le = m.consultarModalidade();
            if (le.Read())
            {
                cod= le["idEstudio_Modalidade"].ToString();
                txtPreco.Text = le["precoModalidade"].ToString();
                txtAluno.Text = le["qtdeAluno"].ToString();
                txtAula.Text = le["qtdeAulas"].ToString();
                if (int.Parse(le["ativa"].ToString()) == 1)
                {
                    checkBox1.Checked=true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Id não encontrado");
            }
            DAO_Conexao.con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            txtPreco.Text = "";
            txtAluno.Text = "";
            txtAula.Text = "";
            comboBox1.Text = "";
        }
    }
}
