using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscolarMusicApp
{
    public partial class FormProfessor : Form
    {
        public FormProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Professor professor = new Professor(
               txtNome.Text, txtCpf.Text, txtEmail.Text, txtTelefone.Text
               );
            professor.Inserir(professor);
            MessageBox.Show("Professor inserido com sucesso!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Professor professor = new Professor();
            foreach (var item in professor.ListarTodos())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.DataCadastro);
            }
        }
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtId.ReadOnly == true)
            {
                txtId.ReadOnly = false;
                button3.Text = "Buscar";

                txtId.Focus();
                LimparCampos();
            }
            else
            {
                if (txtId.Text != string.Empty)
                {
                    Professor professor = new Professor(); 
                    professor.ObterPorId(int.Parse(txtId.Text));
                    if (professor.Id > 0)
                    {
                        txtNome.Text = professor.Nome;
                        txtCpf.Text = professor.Cpf;
                        txtEmail.Text = professor.Email;
                        txtTelefone.Text = professor.Telefone;
                    }
                    else
                    {
                        MessageBox.Show("Professor não cadastrado!");
                    }
                    txtId.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Digite um código para buscar...");
                    txtId.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.Id = int.Parse(txtId.Text);
            professor.Nome = txtNome.Text;
            professor.Telefone = txtTelefone.Text;
            professor.Alterar(professor);
            MessageBox.Show("professor Alterado com sucesso!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
