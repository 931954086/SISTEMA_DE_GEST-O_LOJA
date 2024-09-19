using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class TelefoneFunController
    {
        #region Variáveis

        private TelefoneFunDAO telefoneFunDAO = null;

        #endregion Variáveis

        #region Construtor

        public TelefoneFunController()
        {
            telefoneFunDAO = new TelefoneFunDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneController(TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                return telefoneFunDAO.IncluirTelefoneFunDAO(pTelefoneFunModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarTelefoneCliController(TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                return telefoneFunDAO.AlterarTelefoneFunDAO(pTelefoneFunModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirTelefoneCliController(int pIdTelefone)
        {
            try
            {
                return telefoneFunDAO.ExcluirTelefoneFunDAO(pIdTelefone);
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
        public void ObterTelefonePorFuncionario(ListView lvw, int pIdFuncionario)
        {
            try
            {
                DataTable dt;

                dt = telefoneFunDAO.ObterTelefonePorIdFuncionario(pIdFuncionario);
                lvw.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IdTelefoneFun"].ToString());
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
