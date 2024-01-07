using System;
using System.Windows.Forms;

namespace ProvaN3BuscaCep
{
    public partial class FrmBuscaCep : Form
    {
        public FrmBuscaCep()
        {
            InitializeComponent();
        }

        private async void btnBuscaCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim();

            if (!string.IsNullOrEmpty(cep))
            {
                try
                {
                    BuscaCEP buscaCEP = new BuscaCEP();
                    Endereco endereco = await buscaCEP.ConsultarCEPAsync(cep);

                    txtUF.Text = endereco.UF;
                    txtCidade.Text = endereco.Cidade;
                    txtLogradouro.Text = endereco.Logradouro;
                    txtCodigoIbge.Text = null;
                    txtDDD.Text = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Digite um CEP válido antes de consultar.");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
