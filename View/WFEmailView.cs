using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using SISTEMA_DE_GESTÃO_LOJA.Util;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFEmailView : MetroFramework.Forms.MetroForm
    {
        

        public WFEmailView()
        {
            InitializeComponent();
        }

        private void WFEmailView_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if(Validar(sender, e))
            {
                EnviarEmail();
            }
            else
            {
                return;
            }

        }

        private Boolean Validar(object sender, EventArgs e)
        {
            //TxtRemetente.Text = "techconnetsolutions@gmail.com";
            TxtRemetente.Text = "osvaldoventura931@gmail.com";
            try
            {
                if (!string.IsNullOrEmpty(TxtDestinatario.Text))
                {
                    MailAddress mailAddress;
                    mailAddress = new MailAddress(TxtDestinatario.Text);
                }
                else
                {
                    MGMensagemErro.MensagensErro("O campo " + LblDestinatario.Text + " é de caracter obrigatório.", "20201117-10", "I");
                    TxtDestinatario.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("O campo " + LblDestinatario.Text + " Digite um destinatário válido.", "20201117-10", "A");
                TxtDestinatario.Focus();
                return false;
            }


            try
            {
                if (!string.IsNullOrEmpty(TxtRemetente.Text))
                {
                    MailAddress mailAddress;
                    mailAddress = new MailAddress(TxtRemetente.Text);
                }
                else
                {
                    MGMensagemErro.MensagensErro("O campo " + LblRemetente.Text + " é de caracter obrigatório.", "20201117-10", "I");
                    TxtRemetente.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("O campo " + LblRemetente.Text + " Digite um destinatário válido.", "20201117-10", "A");
                TxtRemetente.Focus();
                return false;
            }

            if (TxtAssunto.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblAssunto.Text + " é obrigatório.", "20201117-10", "a");
                TxtAssunto.Focus();
                return false;
            }

            return true;
        }

        private void EnviarEmail()
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("osvaldoventura931@gmail.com", "Senha931");
                    //smtp.EnableSsl = true;

                    using (MailMessage email = new MailMessage())
                    {
                        email.From = new MailAddress(TxtRemetente.Text);
                        email.To.Add(TxtDestinatario.Text);
                        email.Subject = TxtAssunto.Text;
                        email.IsBodyHtml = false;
                        email.Body = TxtMensagem.Text;

                        smtp.Send(email);
                    }
                }

                MessageBox.Show("Mensagem: " + "Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }
    }
}
