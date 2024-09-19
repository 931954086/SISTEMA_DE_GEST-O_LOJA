using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class TelefoneForController
    {
        #region Variáveis

        private TelefoneForDAO telefoneForDAO = null;

        #endregion Variáveis

        #region Construtor

        public TelefoneForController()
        {
            telefoneForDAO = new TelefoneForDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneForController(TelefoneForModel pTelefoneForModel)
        {
            try
            {
                return telefoneForDAO.IncluirTelefoneForDAO(pTelefoneForModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarTelefoneForController(TelefoneForModel pTelefoneForModel)
        {
            try
            {
                return telefoneForDAO.AlterarTelefoneForDAO(pTelefoneForModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirTelefoneForController(int pIdTelefone)
        {
            try
            {
                return telefoneForDAO.ExcluirTelefoneForDAO(pIdTelefone);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void ObterTelefonePorFornecedor(ListView lvw, int pIdFuncionario)
        {
            try
            {
                DataTable dt;

                dt = telefoneForDAO.ObterTelefonePorIdFornecedor(pIdFuncionario);
                lvw.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IdTelefoneFor"].ToString());
                    item.SubItems.Add(row["IdTipoTelefone"].ToString());
                    item.SubItems.Add(row["DescTipoTel"].ToString());
                    item.SubItems.Add(row["DDD"].ToString());

                    string formatada = row["NumeroTelefone"].ToString().Insert(row["NumeroTelefone"].ToString().Trim().Length - 4, "-");
                    item.SubItems.Add(formatada);
                    //item.SubItems.Add(row["NumeroTelefone"].ToString());

                    lvw.Items.Add(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Métodos
    }
}
