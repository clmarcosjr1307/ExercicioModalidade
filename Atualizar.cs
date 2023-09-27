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
    public partial class Atualizar : Form
    {
        public Atualizar()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text, txtRua.Text, txtNumero.Text, txtBairro.Text,
                txtComplemento.Text, txtCep.Text.Replace(",", "."), txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text);

            if (aluno.atualizarAluno())
            {
                MessageBox.Show("Aluno atualizado!");
                txtCpf.Text = "";
                txtNome.Text= "";
                txtRua.Text= "";
                txtNumero.Text= "";
                txtBairro.Text= "";
                txtComplemento.Text= "";
                txtCep.Text= "";
                txtCidade.Text= "";
                txtEstado.Text= "";
                txtTelefone.Text= "";
                txtEmail.Text= "";
                txtCpf.Enabled = true;
            }
            else
            {
                MessageBox.Show("Erro na atualizção!");
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."));

            if (e.KeyChar == 13)
            {
                MySqlDataReader r = aluno.consultarAluno2();
                if (r.Read())
                {
                    MessageBox.Show("Aluno encontrado!");
                    txtCpf.Enabled = false;
                    txtNome.Text = r["nomeAluno"].ToString();
                    txtComplemento.Text = r["complementoAluno"].ToString();
                    txtBairro.Text = r["bairroAluno"].ToString();
                    txtEmail.Text = r["emailAluno"].ToString();
                    txtCidade.Text = r["cidadeAluno"].ToString();
                    txtCep.Text = r["CEPAluno"].ToString();
                    txtEstado.Text = r["estadoAluno"].ToString();
                    txtNumero.Text = r["numeroAluno"].ToString();
                    txtTelefone.Text = r["telefoneAluno"].ToString();
                    txtRua.Text = r["ruaAluno"].ToString();
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado!");
                }
                DAO_Conexao.con.Close();
            }
             
        }
    }
}
