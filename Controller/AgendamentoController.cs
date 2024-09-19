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
    public class AgendamentoController
    {
        #region Variáveis

        private AgendamentoDAO agendamentoDAO = null;

        #endregion Variáveis

        #region Construtor

        public AgendamentoController()
        {
            agendamentoDAO = new AgendamentoDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirAgendamentoController(AgendamentoModel agendamentoModel, ItemAgendamentoModel itemAgendamentoModel)
        {
            return agendamentoDAO.IncluirAgendamentoDAO(agendamentoModel, itemAgendamentoModel);
        }

        public int AlterarAgendamentoController(AgendamentoModel agendamentoModel)
        {
            return agendamentoDAO.AlterarAgendamentoDAO(agendamentoModel);
        }

        public int ExcluirAgendamentoController(int pIdAgendamento)
        {
            return agendamentoDAO.ExcluirAgendamentoDAO(pIdAgendamento);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros de agendamentos.
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosAgendamento()
        {
            return agendamentoDAO.ObterAllAgendamentos();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarAgendamentos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("AgendamentoId" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public string GerarNumeroFatura()
        {
            return agendamentoDAO.GerarNumeroFatura();
        }

        public void PopularCboCliente(ComboBox cbo)
        {
            ClienteController clienteController = new ClienteController();
            clienteController.PreencherCboCliente(cbo);
        }

        #endregion Métodos
    }

}
