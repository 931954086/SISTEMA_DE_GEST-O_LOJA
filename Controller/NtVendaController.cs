using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class NtVendaController
    {
        #region Variáveis

        private NtVendaDAO ntvendaDAO = null;

        #endregion Variáveis

        #region Construtor

        public NtVendaController()
        {
            ntvendaDAO = new NtVendaDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirNtVendaController(NtVendaModel pNtVendaModel, ItemVendaModel pItemVendaModel)
        {
            return ntvendaDAO.IncluirNtVendaDAO(pNtVendaModel, pItemVendaModel);
        }

        public int AlterarNtVendaController(NtVendaModel pNtVendaModel, ItemVendaModel pItemVendaModel)
        {
            return ntvendaDAO.AlterarNtVendaDAO(pNtVendaModel, pItemVendaModel);
        }

        public int ExcluirNtVendaController(int pIdNtVenda)
        {
            try
            {
                return ntvendaDAO.ExcluirNtVendaDAO(pIdNtVenda);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public DataTable ObterRegistrosNtVenda()
        {
            return ntvendaDAO.ObterTodosNtVenda();
        }

        public DataTable ObterRegistrosNtVenda(int pNumeroFatura)
        {
            return ntvendaDAO.ObterNtVenda(pNumeroFatura);
        }


        public int ContarVendasController()
        {
            DataTable vendas = ntvendaDAO.ObterTodosNtVenda();
            return vendas.Rows.Count;
        }




        /* ==== SEGUE AO ENCONTRO DO PROCEDIMENTO DE FATURA =====*/
        public DataSet LocalizarNtVenda(string pNumeroFatura)
        {
            /* ==== SEGUE AO ENCONTRO DO PROCEDIMENTO DE FATURA =====*/
            return ntvendaDAO.LocalizarNotaFiscalVenda(pNumeroFatura);
        }

        public DataSet LocalizarNtVendaEspecifico(string pNumeroFatura)
        {
            return ntvendaDAO.LocalizarNotaFiscalVendaEspecifico(pNumeroFatura);
        }

        public string GerarNumeroFatura()
        {
            return ntvendaDAO.GerarNumeroNtVenda();
        }

        public void PesquisarProduto(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("DescProduto" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PesquisarCodigoBarra(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("CodigoBarra" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void CarregarDados(DataGridView dtgNtVenda, DataGridView DtgItemVenda, DataGridView DtgTelefoneCli, ComboBox cbo)
        {
            try
            {
                DataViewManager dvManager;

                dvManager = ntvendaDAO.PopularConsultaNtVenda().DefaultViewManager;

                dtgNtVenda.DataSource = dvManager;
                dtgNtVenda.DataMember = "Cliente.RelClienteNtVenda";

                DtgItemVenda.DataSource = dvManager;
                DtgItemVenda.DataMember = "Cliente.RelClienteNtVenda.RelNtVendaItemVenda";

                DtgTelefoneCli.DataSource = dvManager;
                DtgTelefoneCli.DataMember = "Cliente.RelClienteTelefoneCli";

                cbo.DataSource = dvManager;
                cbo.DisplayMember = "Cliente.NomeCli";
                cbo.ValueMember = "Cliente.IdCliente";
                cbo.SelectedIndex = -1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: -> " + ex.Message);
                throw;
            }
        }


        public DataTable GraficoCircularObterTotalVendasController()
        {
            return ntvendaDAO.GraficoCircularObterTotalVendasDAO();
        }

        public DataTable GraficoBarraObterDadosController()
        {
            return ntvendaDAO.GraficoBarraObterDadosVendasDAO();
        }


        #endregion Métodos
    }
}
