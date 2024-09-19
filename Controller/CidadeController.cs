using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class CidadeController
    {
        #region Variáveis

        private CidadeDAO cidadeDAO = null;

        #endregion Variáveis

        #region Construtor

        public CidadeController()
        {
            cidadeDAO = new CidadeDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirCidadeController(CidadeModel cidadeModel)
        {
            return cidadeDAO.IncluirCidadeDAO(cidadeModel);
        }

        public int AlterarCidadeController(CidadeModel cidadeModel)
        {
            return cidadeDAO.AlterarCidadeDAO(cidadeModel);
        }

        public int ExcluirCidadeController(int pIdCidade)
        {
            return cidadeDAO.ExcluirCidadeDAO(pIdCidade);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosCidade()
        {
            return cidadeDAO.ObterAllCidades();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarCidades(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", texto.Replace("'", "''"));
        }

       public void PreencherCboCidade(ComboBox cbo)
        {
            try
            {
                if (cidadeDAO == null)
                {
                    cidadeDAO = new CidadeDAO();
                }
                cbo.DataSource = cidadeDAO.ObterAllCidades();
                cbo.DisplayMember = "NomeCidade";
                cbo.ValueMember = "IdCidade";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PopularCboEstado(ComboBox cbo)
        {
            EstadoController estadoController = new EstadoController();
            estadoController.PreencherCboEstado(cbo);
        }

        #endregion Métodos
    }
}
