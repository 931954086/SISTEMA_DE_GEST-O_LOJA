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
    public class EnderecoCliController
    {

        #region Variáveis

        private EnderecoCliDAO enderecoCliDAO = null;

        #endregion Variáveis

        #region Construtor

     

        #endregion Construtor

        #region Métodos

        public int IncluirEnderecoCliController(EnderecoCliModel enderecoCli)
        {
            return enderecoCliDAO.IncluirEnderecoCliDAO(enderecoCli);
        }

        public int AlterarEnderecoCliController(EnderecoCliModel enderecoCli)
        {
            return enderecoCliDAO.AlterarEnderecoCliDAO(enderecoCli);
        }

        public int ExcluirEnderecoCliController(int pIdEnderecoCliModel)
        {
            return enderecoCliDAO.ExcluirEnderecoCliDAO(pIdEnderecoCliModel);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosEnderecoCli()
        {
            return enderecoCliDAO.ObterAllEnderecoCli();
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

        #endregion Métodos
    }

}

