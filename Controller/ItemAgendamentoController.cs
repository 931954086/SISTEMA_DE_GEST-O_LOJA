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
    public class ItemAgendamentoController
    {
        #region Variáveis

        private ItemAgendamentoDAO itemAgendamentoDAO = null;

        #endregion Variáveis

        #region Construtor

        public ItemAgendamentoController()
        {
            itemAgendamentoDAO = new ItemAgendamentoDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirItemAgendamentoController(ItemAgendamentoModel itemAgendamentoModel)
        {
            return itemAgendamentoDAO.IncluirItemAgendamentoDAO(itemAgendamentoModel);
        }

        public int AlterarItemAgendamentoController(ItemAgendamentoModel itemAgendamentoModel)
        {
            return itemAgendamentoDAO.AlterarItemAgendamentoDAO(itemAgendamentoModel);
        }

        public int ExcluirItemAgendamentoController(int idItemAgendamento)
        {
            return itemAgendamentoDAO.ExcluirItemAgendamentoDAO(idItemAgendamento);
        }

        public DataTable ObterRegistrosItemAgendamento()
        {
            return itemAgendamentoDAO.ObterAllItemAgendamentos();
        }

        public void PesquisarItemAgendamentos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("ItemAgendamentoId" + " like '%{0}%'", texto.Replace("'", "''"));
        }
        #endregion Métodos
    }

}
