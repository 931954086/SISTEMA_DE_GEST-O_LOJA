using Microsoft.Win32;
using SISTEMA_DE_GESTÃO_LOJA.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Security
{
    public partial class WFAtualizarLicencas : MetroFramework.Forms.MetroForm
    {
        public WFAtualizarLicencas()
        {
            InitializeComponent();
        }

        private void RegistarLicencas_Load(object sender, EventArgs e)
        {
            TxtParte1Chave.Text = String.Empty;
            TxtParte2Chave.Text = String.Empty;
            TxtParte3Chave.Text = String.Empty;
            TxtParte4Chave.Text = String.Empty;
        }


        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            /*string parte1 = TxtParte1Chave.Text;
               string parte2 = TxtParte2Chave.Text;
               string parte3 = TxtParte3Chave.Text;
               string parte4 = TxtParte4Chave.Text;
               string chaveFormatada = parte1 + "-" + parte2 + "-" + parte3 + "-" + parte4;
               // Remove os hifens da chave de produto antes de validar
               string chaveProdutoSemHifen = TxtChaveProduto.Text.Replace("-", "");

               // Valida a chave de produto sem hifens
               SKGL.Validate validar = new SKGL.Validate();
               validar.secretPhase = "2000!#";
               validar.Key = chaveProdutoSemHifen;
            */

            string parte1 = TxtParte1Chave.Text;
            string parte2 = TxtParte2Chave.Text;
            string parte3 = TxtParte3Chave.Text;
            string parte4 = TxtParte4Chave.Text;
            string novaChaveLicenca = parte1 + "-" + parte2 + "-" + parte3 + "-" + parte4;


            //string novaChaveLicenca = TxtNovaChaveLicenca.Text.Trim();

            if (!string.IsNullOrEmpty(novaChaveLicenca))
            {
                try
                {
                    // Verifica se a chave de licença é válida e está dentro do prazo
                    SKGL.Validate validar = new SKGL.Validate();
                    validar.secretPhase = "2000!#";
                    validar.Key = novaChaveLicenca;

                    DateTime dataCriacao = validar.CreationDate;
                    DateTime dataExpiracao = dataCriacao.AddDays(validar.DaysLeft);

                    if (validar.IsValid && validar.DaysLeft > 0 && validar.CreationDate.Date >= DateTime.Today)
                    {
                        // Chave de licença válida, salve-a no registro do sistema
                        SalvarLicencaNoRegistro(novaChaveLicenca);
                        MessageBox.Show("Chave de licença válida. A licença foi atualizada.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); // Oculta o formulário após inserir a nova licença
                        AbrirProgramaPrincipal(); // Abre o programa principal
                    }
                    if (validar.IsValid && validar.DaysLeft <= 0)
                    {
                        MessageBox.Show("Chave de licença já utilizada, data de Expiração: " + dataExpiracao, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnCancelar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Chave de licença inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //TxtNovaChaveLicenca.Text = string.Empty;
                        BtnCancelar_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Erro ao validar a chave de licença: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Informação ao validar a chave de licença: " + "Inicia o aplicativo de Gestão como administrador!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close(); // Oculta o formulário após inserir a nova licença
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira uma chave de licença válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AbrirProgramaPrincipal()
        {

            WFLoginView LoginView = new WFLoginView();
            LoginView.ShowDialog();

        }

        private void SalvarLicencaNoRegistro(string chaveLicenca)
        {
            // Define a chave de registro onde a licença será armazenada
            string registryKeyPath = @"SOFTWARE\TechSolutions\GestorLicencas\default";
            string valueName = "true";

            // Abre a chave de registro para escrita
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(registryKeyPath))
            {
                // Define o valor da chave de licença
                key.SetValue(valueName, chaveLicenca);

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // TxtNovaChaveLicenca.Text = string.Empty;
            TxtParte1Chave.Text = string.Empty;
            TxtParte2Chave.Text = string.Empty;
            TxtParte3Chave.Text = string.Empty;
            TxtParte4Chave.Text = string.Empty;
        }

        private bool ValidarCampos()
        {
            // Verifica se o campo de texto do prazo de validade está vazio ou contém apenas espaços em branco
            if (string.IsNullOrWhiteSpace(TxtParte1Chave.Text))
            {
                // Exibe uma mensagem de erro informando que o campo de prazo de validade deve ser preenchido
                MessageBox.Show("Por favor, preencha o 1º campo Chave de Produto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Retorna falso para indicar que a validação falhou
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtParte2Chave.Text))
            {
                MessageBox.Show("Por favor, preencha o 2º campo Chave de Produto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtParte3Chave.Text))
            {
                MessageBox.Show("Por favor, preencha o 3º campo Chave de Produto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtParte4Chave.Text))
            {
                MessageBox.Show("Por favor, preencha o 4º campo Chave de Produto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
