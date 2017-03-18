using Biblioteca.gerente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationForm.gerente
{
    public partial class TelaCadastrarGerente : Form
    {
        public TelaCadastrarGerente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Gerente gerente = new Gerente()
                {
                    Codigo = Convert.ToInt32(numCodigo.Value),
                    Nome = txtNome.Text
                };

                new GerenteNegocio().Insert(gerente);
                MessageBox.Show("Gerente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
