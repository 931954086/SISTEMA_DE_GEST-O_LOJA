using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class TelefoneCliController
    {
        #region Variáveis

        private TelefoneCliDAO telefoneCliDAO = null;

        #endregion Variáveis

        #region Construtor

        public TelefoneCliController()
        {
            telefoneCliDAO = new TelefoneCliDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneController(TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                return telefoneCliDAO.IncluirTelefoneCliDAO(pTelefoneCliModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarTelefoneCliController(TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                return telefoneCliDAO.AlterarTelefoneCliDAO(pTelefoneCliModel);
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
                return telefoneCliDAO.ExcluirTelefoneCliDAO(pIdTelefone);
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
        public void ObterTelefonePorCliente(ListView lvw, int pIdCliente)
        {
            try
            {
                DataTable dt;

                dt = telefoneCliDAO.ObterTelefoneCliPorId(pIdCliente);
                lvw.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IdTelefoneCli"].ToString());
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

        public void ObterTelefonePorCliente(int pIdCliente, ListBox lst)
        {
            try
            {
                lst.DataSource = telefoneCliDAO.ObterTelefoneCliPorId(pIdCliente);
                lst.DisplayMember = "NumeroTelefone";
                lst.ValueMember = "IdCliente";
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Métodos
    }
}
