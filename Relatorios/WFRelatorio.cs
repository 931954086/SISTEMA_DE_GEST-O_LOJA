using Microsoft.Reporting.WinForms;
using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Relatorios
{
    public partial class WFRelatorio : MetroFramework.Forms.MetroForm
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private string numerofatura = String.Empty;
        private NtVendaController fatura;

        public WFRelatorio(string _numerofatura)
        {
            InitializeComponent();
            this.numerofatura = _numerofatura;
            this.fatura = new NtVendaController();
        }
        public WFRelatorio()
        {
            InitializeComponent();
            this.fatura = new NtVendaController();
        }


        private void ImprimirFaturaRel_Load(object sender, EventArgs e)
        {
            ImprimirFatura(this.numerofatura);
            TxtNumeroFatura.Text = this.numerofatura;
        }

        public void ImprimirFatura(string param)
        {
            try
            {


                /* ==== SEGUE AO ENCONTRO DO PROCEDIMENTO DE FATURA =====*/
                DataSet resultado = fatura.LocalizarNtVenda(param);
                MessageBox.Show(" AQUI ESTA O LINK DE IMPRESSÃO DE FATURA");
                ReportDataSource dataSource = new ReportDataSource("DataSet_Fatura", resultado.Tables[0]);


                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                this.reportViewer1.RefreshReport();
                WFRelatorio view = new WFRelatorio();

            }
            catch (Exception ex)
            {
                // Trate exceções conforme necessário
                MessageBox.Show("Erro ao imprimir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFatPesquisa_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            WFRelatorioComPesquisa view = new WFRelatorioComPesquisa();
            ArredondaBordas(view, 15);
            view.ShowDialog();
            view.Dispose();
        }

        // Método para arredondar as bordas de um formulário
        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }
    }
}
