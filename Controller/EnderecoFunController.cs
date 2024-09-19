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
    public class EnderecoFunController
    {

        #region Variáveis

        private EnderecoFunDAO enderecoCliDAO = null;

        #endregion Variáveis

        #region Construtor



        #endregion Construtor

        #region Métodos

        public int IncluirEnderecoCliController(EnderecoFunModel enderecoFun)
        {
            return enderecoCliDAO.IncluirEnderecoFunDAO(enderecoFun);
        }

        public int AlterarEnderecoCliController(EnderecoFunModel enderecoFun)
        {
            return enderecoCliDAO.AlterarEnderecoFunDAO(enderecoFun);
        }

        public int ExcluirEnderecoCliController(int pIdEnderecoFunModel)
        {
            return enderecoCliDAO.ExcluirEnderecoFunDAO(pIdEnderecoFunModel);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosEnderecoFun()
        {
            return enderecoCliDAO.ObterAllEnderecoFun();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarFuncionarios(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeFunc" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        #endregion Métodos
    }
}
