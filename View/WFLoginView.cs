using CriptografiaOsvaldo;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using SISTEMA_DE_GESTÃO_LOJA.Controller;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFLoginView : MetroFramework.Forms.MetroForm
    {
        #region CHAVE DE CRIPTOGRAFIA
        const string chave = "@!1#";
        string senha;
        #endregion CHAVE DE CRIPTOGRAFIA


        private int i;


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public WFLoginView()
        {
            InitializeComponent();
     

        }
        private void WFLoginView_Load(object sender, EventArgs e)
        {
            LimparCampos();
            TxtUsuario.Focus();
            ExibirNomeEmpresaLogin();
        }
        #region BUTTONS



        private void WFLoginView_Enter(object sender, EventArgs e)
        {
            BtnEntrar_Click(sender, e);
        }
        // BtnEntrar_Click(sender, e);

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            try {

                if (TxtSenha.TextLength < 7)
                { 
                    MessageBox.Show("A T E N Ç Ã O:\nA senha deve ter no mímino 7 carateres " + " [ Senha ] " + " e no máximo 12!", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (!Validar())
                {
                    return;
                }

                UsuarioModel usuarioModel = new UsuarioModel();
                List<UsuarioModel> Lista = new List<UsuarioModel>();

                usuarioModel.Login = TxtUsuario.Text.Trim();
                usuarioModel.Senha = Seguranca.Criptografar(TxtSenha.Text.Trim(), chave);


                UsuarioController usuarioController = new UsuarioController();
                Lista = usuarioController.ValidarUsuario(usuarioModel);
          

                if (Lista.Count == 0)
                {
                 ShowTempMessage(LblMensagem, "Usuário não encontrado! Verifique se" +
                     " o nome do Usuário\n\re a Senha estão corretos caso não! Tente novamente.", 10);

                }
                else
                {
                    if (Lista[0].SituacaoModel.IdSituacao == 1)
                    {
                         new WFCredView(Lista);

                     /*   this.Hide();
                        progressBarMenu menu = new progressBarMenu(Lista[0].TipoUsuarioModel.IdTipoUsuario, Lista[0].Login, Lista[0].TipoUsuarioModel.SiglaTipoUsuario, Lista[0].FuncionarioModel.NomeFunc, Lista[0].FuncionarioModel.IdFuncionario);
                        menu.ShowDialog();
                        menu.Dispose();
                       //Application.Exit();*/

                         
                        this.Hide();
                        WFPrincipalView wFPrincipalView = new WFPrincipalView( Lista[0].TipoUsuarioModel.IdTipoUsuario, Lista[0].Login, Lista[0].TipoUsuarioModel.SiglaTipoUsuario, Lista[0].FuncionarioModel.NomeFunc, Lista[0].FuncionarioModel.IdFuncionario);
                        //ArredondaBordas(wFPrincipalView, 10);
                        wFPrincipalView.ShowDialog();
                        wFPrincipalView.Dispose();
                        Application.Exit();
                    }
                    else
                    {
                        LblMensagem.Text = "Usuário Inactivo! Sem permissão de acesso ao sistema!";
                    }
                }

            } 
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("ERRO => " + ex.Message ,  "20230903-09", "E");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            TxtUsuario.Focus();
        }
        #endregion BUTTONS


        #region TEXTBOX
        private void checkBoxVerSenha_CheckedChanged(object sender, EventArgs e)
        {

            if(checkBoxVerSenha.Checked)
            {
               TxtSenha.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
               this.senha = TxtSenha.Text;
            }
            else
            {
                //TxtSenha.TextMaskFormat = MaskFormat.IncludeLiterals;
                this.senha =  string.Empty;
            }
            LblSenhadecod.Text = this.senha;
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtSenha.Focus();
            }
        }

        private void TxtSenha_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            //Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnEntrar.Focus();
            }
        }

        private void TxtSenha_Leave(object sender, EventArgs e)
        {
            //Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        #endregion TEXTBOX


        #region METODOS




        EmpresaController empresaController = new EmpresaController();
        public string ExibirNomeEmpresaLogin()
        {
            try
            {
                string nomeEmpresa = empresaController.ObterNomeEmpresaController();
                LblNomeEmpresa.Text = nomeEmpresa;
                return nomeEmpresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter o nome da empresa: " + ex.Message);
                return string.Empty;
            }
        }




        // Método para arredondar as bordas de um formulário
        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }



        private bool Validar()
        {
            if (TxtUsuario.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeUsuario.Text + " é obrigatório.", "20200720-02", "a");
                TxtUsuario.Focus();
                return false;
            }

            if (TxtSenha.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSenha.Text + " é obrigatório.", "20200720-02", "a");
                TxtSenha.Focus();
                return false;
            }
            return true;
        }

        private void LimparCampos()
        {
            LblMensagem.Text = TxtUsuario.Text = TxtSenha.Text = string.Empty;
            TxtUsuario.Focus();
        }
        private void LblSenhadecod_Click(object sender, EventArgs e)
        {

        }



        public async void ShowTempMessage(Label label, string message, int durationInSeconds)
        {
            LblMensagem.Text = message;
            await Task.Delay(durationInSeconds * 1000);
            LblMensagem.Text = "";
        }

      /*
        public void MetodoDemorado()
        {
            Console.WriteLine("Início do método");
            // Pausa a execução por 30 segundos
            Thread.Sleep(30000); // 30000 milissegundos = 30 segundos
        }
      */


        private void VerSenha_Click(object sender, EventArgs e)
        {
            if (checkBoxVerSenha.Checked)
            {
                TxtSenha.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                this.senha = TxtSenha.Text;
            }
            else
            {
                //TxtSenha.TextMaskFormat = MaskFormat.IncludeLiterals;
                this.senha = string.Empty;
            }
            LblSenhadecod.Text = this.senha;
        }


        #endregion METODOS

        private void LinkRecuperarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WFRecuperarSenhaView wWFRecuperarSenhaView = new View.WFRecuperarSenhaView();
         
            wWFRecuperarSenhaView.ShowDialog();
            wWFRecuperarSenhaView.Dispose();

        }

       
    }
}
