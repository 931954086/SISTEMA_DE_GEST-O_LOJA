using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class ItemVendaController
    {
        #region Variáveis

        private ItemVendaDAO itemVendaDAO = null;
   
        #endregion Variáveis

        #region Construtor

        public ItemVendaController()
        {
            itemVendaDAO = new ItemVendaDAO();
        }

        #endregion Construtor

        #region Métodos
        public int IncluirProdutoController(ItemVendaModel pItemVendaModel)
        {
            return itemVendaDAO.IncluirItemVendaDAO(pItemVendaModel);
        }


        public int AlterarProdutoController(ItemVendaModel pItemVendaModel)
        {
            return itemVendaDAO.AlterarItemVendaDAO(pItemVendaModel);
        }

        #endregion Métodos
    }
}
