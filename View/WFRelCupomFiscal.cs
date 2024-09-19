using Microsoft.Reporting.WinForms;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
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
    public partial class WFRelCupomFiscal : MetroFramework.Forms.MetroForm
    {
        private string numeroFatura;
        public WFRelCupomFiscal(string _numeroFatura)
        {
            InitializeComponent();
            this.numeroFatura = _numeroFatura;
            ExibirCupom();
        }

        public WFRelCupomFiscal()
        {
            InitializeComponent();
            ExibirCupomBotao();
        }


        private void ExibirCupom()
        {
            try
            {
              NtVendaModel ntVendaModel = new NtVendaModel();
              ntVendaModel.NomeRel = "Nota Fiscal (Fatura)";
              ntVendaModel.Numerofatura = this.numeroFatura;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void WFRelCupomFiscal_Load(object sender, EventArgs e)
        {

            this.RptRelatorio.RefreshReport();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirCupomBotao();
        }


        private void ExibirCupomBotao()
        {
            try
            {
                NtVendaModel ntVendaModel = new NtVendaModel();
                ntVendaModel.NomeRel = "Nota Fiscal (Fatura)";
                this.numeroFatura = TxtPesquisarNumeroFatura.Text;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
