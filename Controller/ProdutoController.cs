using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class ProdutoController
    {
        #region Variáveis

        private ProdutoDAO produtoDAO = null;
        private ItemVendaModel itemVendaModel = null;

        #endregion Variáveis

        #region Construtor

        public ProdutoController()
        {
            produtoDAO = new ProdutoDAO();
            //itemVendaModel = new ItemVendaModel();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirProdutoController(ProdutoModel pProdutoModel)
        {
            return produtoDAO.IncluirProdutoDAO(pProdutoModel);
        }



        public int AlterarProdutoController(ProdutoModel pProdutoModel, bool pGravarHistorico)
        {
            return produtoDAO.AlterarProdutoDAO(pProdutoModel, pGravarHistorico);
        }

    

        public int ExcluirProdutoController(int pIdProduto)
        {
            return produtoDAO.ExcluirProdutoDAO(pIdProduto);
        }

       


        public DataTable ObterRegistrosProduto()
        {
            return produtoDAO.ObterTodosProdutos();
        }

        public int ContarProdutosController()
        {
            DataTable produtos = produtoDAO.ObterTodosProdutos();
            return produtos.Rows.Count;
        }


        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarProdutos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("DescProduto" + " like '%{0}%'", texto.Replace("'", "''"));
        }



        public void PesquisarProdutosPorCodBarra(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("CodigoBarra" + " like '%{0}%'", texto.Replace("'", "''"));
        }

      

        #endregion Métodos
    }
}
