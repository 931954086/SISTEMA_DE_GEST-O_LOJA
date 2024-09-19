using Microsoft.Reporting.WinForms;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Relatorios
{
    public partial class WFRelatorioComPesquisa : MetroFramework.Forms.MetroForm
    {



        private NtVendaController fatura;
        private string numerofatura;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,
          int nTopRect,
          int RightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
        );
        public WFRelatorioComPesquisa()
        {
            InitializeComponent();
            this.fatura = new NtVendaController();
        }

        private void RelatorioComPesquisa_Load(object sender, EventArgs e)
        {

  
        }


        private void IconBtnPesquisar_Click(object sender, EventArgs e)
        {
              this.numerofatura = TxtPesquisaNum.Text;
              ImprimirFatura(this.numerofatura);
        }

        public void ImprimirFatura(string param)
        {
            try
            {
                MessageBox.Show(" AQUI ESTA O LINK DE IMPRESSÃO DE FATURA ESPECÍFICA");
                DataSet resultado = fatura.LocalizarNtVendaEspecifico(param);

                if (resultado != null && resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
                {
                    // A fatura existe e há dados retornados no DataSet
                    ReportDataSource dataSource = new ReportDataSource("DataSet_Fatura", resultado.Tables[0]);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    // A fatura não existe ou o DataSet está vazio
                    LimparFatura();
                    MessageBox.Show("A fatura correspondente não foi encontrada. Certifique-se de que a fatura foi criada antes de prosseguir.",
                                    "Fatura não encontrada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                    );
                }
                

            }
            catch (Exception ex)
            {
                // Trate exceções conforme necessário
                MessageBox.Show("Erro ao imprimir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IconBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparFatura();
        }

        private void LimparFatura()
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();
        }
    }
}
