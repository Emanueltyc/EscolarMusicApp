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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //criar uma instância de Form1 (FrmAluno)
            FormAluno frmAluno = new FormAluno();
            frmAluno.MdiParent = this;
            frmAluno.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();

            formLogin.ShowDialog();
            if (Program.userLogado != null)
            {
                Text = "Usuário: " + Program.userLogado.Nome;
            }

        }

        private void matrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMatricula frmMatricula = new FormMatricula();
            frmMatricula.MdiParent = this;
            frmMatricula.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void professorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProfessor formProfessor = new FormProfessor();
            formProfessor.MdiParent = this;
            formProfessor.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCurso formCurso = new FormCurso();
            formCurso.MdiParent = this;
            formCurso.Show();
        }
    }
}
