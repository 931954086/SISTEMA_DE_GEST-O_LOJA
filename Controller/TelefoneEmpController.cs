using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class TelefoneEmpController
    {
        #region Variáveis

        private TelefoneEmpDAO telefoneEmpDAO = null;

        #endregion Variáveis

        #region Construtor

        public TelefoneEmpController()
        {
            telefoneEmpDAO = new TelefoneEmpDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneEmpreController(TelefoneEmpModel pTelefoneEmpModel)
        {
            try
            {
                return telefoneEmpDAO.IncluirTelefoneEmpreDAO(pTelefoneEmpModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarTelefoneEmpreController(TelefoneEmpModel pTelefoneEmpModel)
        {
            try
            {
                return telefoneEmpDAO.AlterarTelefoneEmpreDAO(pTelefoneEmpModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirTelefoneEmpreController(int pIdTelefone)
        {
            try
            {
                return telefoneEmpDAO.ExcluirTelefoneEmpreDAO(pIdTelefone);
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
        public void ObterTelefonePorEmpresa(ListView lvw, int pIdEmpresa)
        {
            try
            {
                DataTable dt;

                dt = telefoneEmpDAO.ObterTelefonePorIdEmpresa(pIdEmpresa);
                lvw.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IdTelefoneEmpre"].ToString());
                    item.SubItems.Add(row["DDD"].ToString());
                    item.SubItems.Add(row["NumeroTelefone"].ToString());
                    item.SubItems.Add(row["IdTipoTelefone"].ToString());
                    item.SubItems.Add(row["IdEmpresa"].ToString());
           
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
