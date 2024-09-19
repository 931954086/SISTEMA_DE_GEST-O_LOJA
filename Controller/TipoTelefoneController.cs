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
    public class TipoTelefoneController
    {
        #region Variáveis

        private TipoTelefoneDAO tipoTelefoneDAO = null;

        #endregion Variáveis

        #region Construtor

        public TipoTelefoneController()
        {
            tipoTelefoneDAO = new TipoTelefoneDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTipoTelefonelController(TipoTelefoneModel pTipoTelefoneModel)
        {
            return tipoTelefoneDAO.IncluirTipoTelefoneDAO(pTipoTelefoneModel);
        }

        public int AlterarTipoTelefonelController(TipoTelefoneModel pTipoTelefoneModel)
        {
            return tipoTelefoneDAO.AlterarTipoTelefoneDAO(pTipoTelefoneModel);
        }

        public int ExcluirTipoTelefonelController(int pIdTipoTelefonel)
        {
            return tipoTelefoneDAO.ExcluirTipoTelefoneDAO(pIdTipoTelefonel);
        }

        public DataTable ObterRegistrosTipoTelefone()
        {
            return tipoTelefoneDAO.ObterTodosTipoTelefone();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarTipoTelefone(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("DescTipoTel" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        #endregion Métodos
    }
}
