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
    public class SituacaoController
    {
        #region Variáveis

        private SituacaoDAO situacaoDAO = null;

        #endregion Variáveis

        #region Construtor

        public SituacaoController()
        {
            situacaoDAO = new SituacaoDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirSituacaoController(SituacaoModel pSituacaoModel)
        {
            return situacaoDAO.IncluirSituacaoDAO(pSituacaoModel);
        }

        public int AlterarSituacaoController(SituacaoModel pSituacaoModel)
        {
            return situacaoDAO.AlterarSituacaoDAO(pSituacaoModel);
        }

        public int ExcluirSituacaoController(int pIdSituacao)
        {
            return situacaoDAO.ExcluirSituacaoDAO(pIdSituacao);
        }

        public DataTable ObterRegistrosSituacao()
        {
            return situacaoDAO.ObterTodasSituacoes();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarSituacaos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("DescSituacao" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PreencherCboSituacao(ComboBox cbo)
        {
            cbo.DataSource = situacaoDAO.ObterTodasSituacoes();
            cbo.DisplayMember = "DescSituacao";
            cbo.ValueMember = "IdSituacao";
        }
        #endregion Métodos
    }
}
