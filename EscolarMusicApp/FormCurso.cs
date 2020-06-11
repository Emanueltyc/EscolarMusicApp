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
    public partial class FormCurso : Form
    {
        public FormCurso()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso(
               txtNome.Text, int.Parse(txtCarga.Text), double.Parse(txtValor.Text));
            curso.Inserir(curso);
            MessageBox.Show("Curso inserido com sucesso!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Curso curso = new Curso();
            foreach (var item in curso.ListarTodos())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.CargaHoraria + " - " + item.Valor);
            }
        }
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCarga.Clear();
            txtValor.Clear();
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
                    Curso curso = new Curso();
                    curso.ObterPorId(int.Parse(txtId.Text));
                    if (curso.Id > 0)
                    {
                        txtNome.Text = curso.Nome;
                        txtCarga.Text = Convert.ToString(curso.CargaHoraria);
                        txtValor.Text = Convert.ToString(curso.Valor);
                    }
                    else
                    {
                        MessageBox.Show("Curso não cadastrado!");
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
            Curso curso = new Curso();
            curso.Id = int.Parse(txtId.Text);
            curso.Nome = txtNome.Text;
            curso.CargaHoraria = int.Parse(txtCarga.Text);
            curso.Valor = double.Parse(txtValor.Text);
            curso.Alterar(curso);
            MessageBox.Show("Curso Alterado com sucesso!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
