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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text,txtRua.Text,txtNumero.Text,txtBairro.Text,
                txtComplemento.Text,txtCep.Text.Replace(",", "."), txtCidade.Text,txtEstado.Text,txtTelefone.Text,txtEmail.Text);

            if (aluno.cadastrarAluno())
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            else {
                MessageBox.Show("Erro no cadastro!");
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text);

            if (e.KeyChar == 13) {
                if (aluno.consultarAluno())
                {
                    MessageBox.Show("Aluno já cadastrado!");
                }
                else {
                    MessageBox.Show("Aluno não cadastrado!");
                    txtNome.Focus();
                }
                DAO_Conexao.con.Close();
            }
        }

      
    }
}
