using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Relatorios;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFConsultaNtVendaView : Form
    {
        #region Variaves
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private NtVendaController ntVendaController = null;


        List<int> ListaLarguraColunaTelefoneCli = new List<int>(){20, 30,45 };
        List<int> ListaLarguraColunaNtVenda = new List<int>(){15, 11, 15, 12, 16, 15, 15};
        List<int> ListaLarguraColunaItemVenda = new List<int>(){12, 15, 38, 20, 15};


        List<string> ListaColunaVisevelTel = new List<string>() {"DDD", "Nº Tel", "Tipo Tel"};
        List<string> ListaColunaVisevelNtVenda = new List<string>() {"Nº Fatura", "Dt. Venda","Valor Bruto", "Desconto","Imposto", "Valor Liq", "Situação"};
        List<string> ListaColunaVisevelItemVenda = new List<string>() {"Nº Fatura", "Código Produto","Produto", "Valor Unit","Quantidade" };

        #endregion Variaves


        #region Constructor
        public WFConsultaNtVendaView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);

            ntVendaController= new NtVendaController();
        }
        #endregion Constructor

        #region Eventos



        #region Forms
        private void WFConsultaNtVendaView_Load(object sender, EventArgs e)
        {
            // Configuração da fonte para o cabeçalho
            DtgTelefoneCli.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgTelefoneCli.DefaultCellStyle.Font = new Font("Arial", 12);

            // Configuração da fonte para o cabeçalho
            DtgNtVenda.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgNtVenda.DefaultCellStyle.Font = new Font("Arial", 12);

            // Configuração da fonte para o cabeçalho
            DtgItemVenda.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgItemVenda.DefaultCellStyle.Font = new Font("Arial", 12);

            /* try
             {
                 PadraoForm.BotaoMinimizarForm(this);
             }
             catch (Exception ex)
             {
                 MGMensagemErro.MensagensErro(ex.Message, "2023147", "e");
             }*/
        }


        private void WFConsultaNtVendaView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BtnCancelar_Click(sender, e);
            }
        }

 
        private void CboCliente_Enter(object sender, EventArgs e)
        {
            this.CboCliente.MaxDropDownItems = 6;
        }

        #endregion Forms



        #endregion Eventos

        #region Botoes
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CboCliente.SelectedIndex = -1;
            TelaInicial(true);

        }


        private void BtnCancelarNota_Click(object sender, EventArgs e)
        {
            int idcli = Convert.ToInt32(CboCliente.SelectedValue);

            DataGridViewRow LinhaAtual = DtgNtVenda.CurrentRow;

            int indice = LinhaAtual.Index;

            int idvenda = Convert.ToInt32(DtgNtVenda.Rows[indice].Cells["IdNtVenda"].Value);


            if (MessageBox.Show("Deseja Realmente cancelar a fatura Nº " + DtgNtVenda.Rows[indice].Cells["Nº Fatura"].Value.ToString() + "?", "Confirmação",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                NtVendaController ntVendaController = new NtVendaController();
                ntVendaController.ExcluirNtVendaController(idvenda);
            }

           /*  try
            {
                NtVendaController ntVendaController = new NtVendaController();
                ntVendaController.ExcluirNtVendaController(idvenda);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20200721-01", "e");
            }*/

            TelaInicial(false);
            this.CboCliente.SelectedValue = idcli;

        }
        #endregion Botoes




        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }


        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            TelaInicial(true);
            base.OnLoad(e);
        }
        #endregion OnLoad


        #region Metodos 
        private void TelaInicial(bool bolIni)
        {
            ntVendaController.CarregarDados(DtgNtVenda, DtgItemVenda, DtgTelefoneCli, CboCliente);

            Application.DoEvents();

            EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgTelefoneCli, ListaColunaVisevelTel);
            EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgNtVenda,     ListaColunaVisevelNtVenda);
            EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgItemVenda,   ListaColunaVisevelItemVenda);

            EstilizarDataGridView.DefinirLargurasDataGridView(DtgTelefoneCli, ListaLarguraColunaTelefoneCli);
            EstilizarDataGridView.DefinirLargurasDataGridView(DtgNtVenda,     ListaLarguraColunaNtVenda);
            EstilizarDataGridView.DefinirLargurasDataGridView(DtgItemVenda,   ListaLarguraColunaItemVenda);

            if (bolIni)
            {
                EstilizarDataGridView.EstiloDataGridView(DtgTelefoneCli);
                EstilizarDataGridView.EstiloDataGridView(DtgNtVenda);
                EstilizarDataGridView.EstiloDataGridView(DtgItemVenda);
            }
            this.CboCliente.Focus();
        }



        #endregion  Metodos 

        private void BtnFaturaPDF_Click(object sender, EventArgs e)
        {
          
                //this.Hide();
                //this.Dispose();
                WFRelatorioComPesquisa view = new WFRelatorioComPesquisa();
                ArredondaBordas(view, 15);
                view.ShowDialog();
                view.Dispose();
            
        }


        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }

        private void BtnBalanco_Click(object sender, EventArgs e)
        {

        }
    }
}
