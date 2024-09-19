using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFRecuperarSenhaView : MetroFramework.Forms.MetroForm
    {

        #region CHAVE DE CRIPTOGRAFIA
        const string chave = "@!1#";
        string senha;
        #endregion CHAVE DE CRIPTOGRAFIA
        public WFRecuperarSenhaView()
        {
            InitializeComponent();
        }

        private void WFRecuperarSenhaView_Load(object sender, EventArgs e)
        {

        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar(sender, e))
                {
                    return;
                }

                UsuarioModel usuarioModel = new UsuarioModel();
                List<UsuarioModel> Lista = new List<UsuarioModel>();

                usuarioModel.Email = TxtEmail.Text.Trim();

                UsuarioController usuarioController = new UsuarioController();
                Lista = usuarioController.RecuperarSenhaUsuarioController(usuarioModel);


                if (Lista.Count > 0)
                {
                    string TextoDescriptografado = TxtResultadoSenha.Text = Lista[0].Senha;
                    TxtResultadoSenha.Text = CriptografiaOsvaldo.Seguranca.DesCriptografar(TextoDescriptografado, chave);
                   

                      ShowTempMessage(LblMensagemTexto, " --    Por razões de segurança não enviamos a sua senha, \r\n na caixa de resultado! \r\n\n\n" +
                        " --     Mas já pode aceder sua conta, apartir da sua\r\n senha enviada no seu email! \r\n", 10);

                }
                else
                {
                    // Lidar com o caso em que nenhum usuário foi encontrado.
                    ShowTempMessage(LblMensagemTexto, " --    Usuário não encontrado! " + " Por favor digite email \r\nde usuário cadastrado no sistema!", 10);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

        }



        public async void ShowTempMessage(Label label, string message, int durationInSeconds)
        {
            LblMensagemTexto.Text = message;
            await Task.Delay(durationInSeconds * 1000);
            LblMensagemTexto.Text  = "";
            TxtResultadoSenha.Text = "";


        }

       
            private Boolean Validar(object sender, EventArgs e)
            {
                try
                {
                    if (!string.IsNullOrEmpty(TxtEmail.Text))
                    {
                        MailAddress mailAddress;
                        mailAddress = new MailAddress(TxtEmail.Text);
                    }
                    else
                    {
                        MGMensagemErro.MensagensErro("O campo " + "Email" + " é de caracter obrigatório.", "20201117-10", "I");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MGMensagemErro.MensagensErro("O campo " + "Email" + " Digite um email válido.", "20201117-10", "A");
                    return false;
                }
               return true;
            }

  }
}
