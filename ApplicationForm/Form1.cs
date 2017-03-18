using ApplicationForm.gerente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationForm
{
    public partial class Form1 : Form
    {

        private static TelaCadastrarGerente telaCadastrarGerente;

        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (telaCadastrarGerente == null)
            {
                telaCadastrarGerente = new TelaCadastrarGerente();
                telaCadastrarGerente.MdiParent = this;
                telaCadastrarGerente.FormClosed += TelaCadastrarGerente_FormClosed;
                telaCadastrarGerente.Show();
            }
            else
            {
                telaCadastrarGerente.Activate();
            }
        }

        private void TelaCadastrarGerente_FormClosed(object sender, FormClosedEventArgs e)
        {
            telaCadastrarGerente = null;
        }
    }
}
