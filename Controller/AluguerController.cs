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
    public class AluguerController
    {

        #region Variáveis

        private AluguerDAO aluguerDAO = null;

        #endregion Variáveis

        #region Construtor

        public AluguerController()
        {
            aluguerDAO = new AluguerDAO();
        }

        #endregion Construtor


        #region METODOS 
        public int IncluirAluguerController(AluguerModel aluguerModel, ItemAluguerModel itemAluguerModel)
        {
            return aluguerDAO.IncluirAluguerDAO(aluguerModel, itemAluguerModel);
        }

        public int AlterarAluguerController(AluguerModel aluguerModel)
        {
            return aluguerDAO.AlterarAluguerDAO(aluguerModel);
        }

        public int ExcluirCidadeController(int pIdAluguer)
        {
            return aluguerDAO.ExcluirAluguerDAO(pIdAluguer);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosAluguer()
        {
            return aluguerDAO.ObterAllAlugueres();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarAlugueres(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("AluguelId" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public string GerarNumeroFatura()
        {
            return aluguerDAO.GerarNumeroNtVenda();
        }

        public void PopularCboCliente(ComboBox cbo)
        {
            ClienteController clienteController = new ClienteController();
            clienteController.PreencherCboCliente(cbo);
        }
        #endregion METODOS 
    }
}
