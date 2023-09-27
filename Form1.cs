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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DAO_Conexao.getConexao("143.106.241.3", "cl202157", "cl202157", "Jclm19ec@"))
                Console.WriteLine("Conectado");
            else 
                Console.WriteLine("Erro de conexão");
        }


        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAO_Conexao.VerificaLogin(textBox1.Text, textBox2.Text);
            if (tipo == 0)
                MessageBox.Show("Usuário/Senha inválidos");
            if (tipo == 1)
            {
                MessageBox.Show("Usuário ADM");
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
            }
            if (tipo == 2) {
                MessageBox.Show("Usuário Restrito");
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarAlunoToolStripMenuItem.Enabled = false;
                atualizarOuConsultarModalidadeToolStripMenuItem.Enabled = false;
                excluirModalidadeToolStripMenuItem.Enabled = false;
                cadastrarModalidadeToolStripMenuItem.Enabled = false;

            }
        }

        private void excluirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excluir excluir = new Excluir();
            excluir.MdiParent = this;
            excluir.Show();
        }

        private void atualizarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Atualizar atualizar = new Atualizar();
            atualizar.MdiParent = this;
            atualizar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cadastrarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarModalidade cadastrar = new CadastrarModalidade();
            cadastrar.MdiParent = this;
            cadastrar.Show();
        }

        private void excluirModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirModalidade excluir = new ExcluirModalidade();
            excluir.MdiParent = this;
            excluir.Show();
        }

        private void atualizarOuConsultarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarModalidade consultar = new ConsultarModalidade();
            consultar.MdiParent = this;
            consultar.Show();
        }


    }
}
