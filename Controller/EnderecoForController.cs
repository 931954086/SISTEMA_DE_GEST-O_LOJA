using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class EnderecoForController
    {

        #region Variáveis

        private EnderecoForDAO enderecoForDAO = null;

        #endregion Variáveis

        #region Construtor



        #endregion Construtor

        #region Métodos

        public int IncluirEnderecoCliController(EnderecoForModel enderecoFor)
        {
            return enderecoForDAO.IncluirEnderecoForDAO(enderecoFor);
        }

        public int AlterarEnderecoCliController(EnderecoForModel enderecoFor)
        {
            return enderecoForDAO.AlterarEnderecoForDAO(enderecoFor);
        }

        public int ExcluirEnderecoCliController(int pIdEnderecoForModel)
        {
            return enderecoForDAO.ExcluirEnderecoForDAO(pIdEnderecoForModel);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosEnderecoFor()
        {
            return enderecoForDAO.ObterAllEnderecoFor();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarFornecedores(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeFor" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        #endregion Métodos
    }
}
