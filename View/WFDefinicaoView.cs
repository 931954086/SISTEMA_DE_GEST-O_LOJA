using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFDefinicaoView : MetroFramework.Forms.MetroForm
    {
        private string login;

        public WFDefinicaoView()
        {
            InitializeComponent();
        }
        private void WFDefinicaoView_Load(object sender, EventArgs e)
        {
            
        }


        #region ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========
        private void loadtheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                }
            }
            //LblTotalRegistros.ForeColor = ThemeColor.SecondaryColor;
            // LblNumCodigo.ForeColor = ThemeColor.PrimaryColor;
            panelBar.BackColor = ThemeColor.PrimaryColor;
            this.BackColor = Color.White;
        }

        private string GetLogin()
        {
            return login;
        }
        #endregion ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========
        private void BtnSenha_Click(object sender, EventArgs e)
        {
            Form form = new View.WFCredView();
            form.ShowDialog();
            form.Dispose();
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            Form form = new View.WFEmailView();
            form.ShowDialog();
            form.Dispose();
        }
    }
}
