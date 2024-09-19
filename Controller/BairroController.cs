using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class BairroController
    {
        #region Variáveis

        private BairroDAO bairroDAO = null;

        #endregion Variáveis

        #region Construtor

        public BairroController()
        {
            bairroDAO = new BairroDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirBairroController(BairroModel bairroModel)
        {
            return bairroDAO.IncluirBairroDAO(bairroModel);
        }

        public int AlterarBairroController(BairroModel bairroModel)
        {
            return bairroDAO.AlterarBairroDAO(bairroModel);
        }

        public int ExcluirBairroController(int pIdBairro)
        {
            return bairroDAO.ExcluirBairroDAO(pIdBairro);
        }

      
        public DataTable ObterRegistrosBairro()
        {
            return bairroDAO.ObterAllBairros();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarBairros(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeBairros" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PreencherCboBairro(ComboBox cbo)
        {
            try
            {
                if (bairroDAO == null)
                {
                    bairroDAO = new BairroDAO();
                }
                cbo.DataSource    = bairroDAO.ObterAllBairros();
                cbo.DisplayMember = "NomeBairro";
                cbo.ValueMember   = "IdBairro";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PopularCboCidade(ComboBox cbo)
        {
            try
            {
                if (bairroDAO == null)
                {
                    bairroDAO = new BairroDAO();
                }
                cbo.DataSource = bairroDAO.ObterAllCidades();
                cbo.DisplayMember = "NomeCidade";
                cbo.ValueMember = "IdCidade";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos

    }
} 
