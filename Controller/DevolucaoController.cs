using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class DevolucaoController
    {
        #region Variáveis

        private DevolucaoDAO devolucaoDAO = null;

        #endregion Variáveis

        #region Construtor

        public DevolucaoController()
        {
            devolucaoDAO = new DevolucaoDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirDevolucaoController(DevolucaoModel pdevolucaoModel)
        {
            return devolucaoDAO.IncluirDevolucaoDAO(pdevolucaoModel);
        }

        public int AlterarDevolucaoController(DevolucaoModel pdevolucaoModel)
        {
            return devolucaoDAO.AlterarDevolucaoDAO(pdevolucaoModel);
        }

        public int ExcluirDevolucaoController(int pIdDevolucao)
        {
            return devolucaoDAO.ExcluirDevolucaoDAO(pIdDevolucao);
        }


        public DataTable ObterRegistrosDevolucao()
        {
            return devolucaoDAO.ObterAllDevolucao();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarDevolucao(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("DevolucaoId" + " like '%{0}%'", texto.Replace("'", "''"));
        }



        public void PopularCboAluguer(ComboBox cbo)
        {
            try
            {
                AluguerDAO aluguerDAO = new AluguerDAO();
                if (aluguerDAO == null)
                {
                    aluguerDAO  = new AluguerDAO();
                }
                cbo.DataSource = aluguerDAO.ObterAllAlugueres();
                cbo.DisplayMember = "NomeCidade";
                cbo.ValueMember = "IdCidade";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
