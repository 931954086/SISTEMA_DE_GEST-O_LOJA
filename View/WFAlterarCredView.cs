using CriptografiaOsvaldo;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFCredView : MetroFramework.Forms.MetroForm
    {


        UsuarioModel usuarioModel = new UsuarioModel();
        private string login;
        #region CHAVE DE CRIPTOGRAFIA
        const string chave = "@!1#";
        string senha;
        #endregion CHAVE DE CRIPTOGRAFIA

        public WFCredView(List<UsuarioModel> lista)
        {
            this.login = lista[0].Login;
            InitializeComponent();
        }

        public WFCredView()
        {
            InitializeComponent();
        }

        private void WFCredView_Load(object sender, EventArgs e)
        {

        }


        private void checkBoxVerSenha_CheckedChanged(object sender, EventArgs e)
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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    return;
                }

                UsuarioController usuarioController = new UsuarioController();
                usuarioModel.Senha = Seguranca.Criptografar(TxtSenha.Text.Trim(), chave);
                usuarioModel.Login = TxtUsuario.Text;

                usuarioController.AlterarSenhaController(usuarioModel);

            }
            catch (Exception ex)
            {

                MGMensagemErro.MensagensErro("ERRO => " + ex.Message, "20230903-09", "E");
            }
        }


        private bool Validar()
        {

            if (TxtUsuario.TextLength < 5)
            {
                MessageBox.Show("A T E N Ç Ã O:\nO Usuario deve ter no mímino 4 carateres " + "  " + " e no máximo 12!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (TxtUsuario.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + TxtUsuario.Text + " é obrigatório.", "20200720-02", "a");
                TxtUsuario.Focus();
                return false;
            }

            if (TxtSenha.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSenha.Text + " é obrigatório.", "20200720-02", "a");
                TxtSenha.Focus();
                return false;
            }

            if (TxtSenha.TextLength < 7)
            {
                MessageBox.Show("A T E N Ç Ã O:\nA senha deve ter no mímino 7 carateres " + " [ Senha ] " + " e no máximo 12!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (TxtSenha.Text.Trim() != TxtConfirmarSenha.Text.Trim())
            {
                MGMensagemErro.MensagensErro("O campo " + LblConfirmarSenha.Text + " As senha são diferentes! por favor reveja.", "20200720-02", "a");
                TxtConfirmarSenha.Focus();
                return false;
            }

           
            return true;
        }

    
    }
}
