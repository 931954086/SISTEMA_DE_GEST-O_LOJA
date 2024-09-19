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
    public class MaterialController
    {
        #region Variáveis

        private MaterialDAO materialDAO = null;

        #endregion Variáveis

        #region Construtor

        public MaterialController()
        {
            materialDAO = new MaterialDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirMaterialController(MaterialModel materialModel)
        {
            return materialDAO.IncluirMaterialDAO(materialModel);
        }

        public int AlterarMaterialController(MaterialModel materialModel)
        {
            return materialDAO.AlterarMaterialDAO(materialModel);
        }

        public int ExcluirMaterialController(int pIdMaterial)
        {
            return materialDAO.ExcluirMaterialDAO(pIdMaterial);
        }


        public DataTable ObterRegistrosMaterial()
        {
            return materialDAO.ObterAllMaterias();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarMaterial(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("Nome " + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PesquisarCodigoBarra(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("CodigoBarra" + " like '%{0}%'", texto.Replace("'", "''"));
        }





        #endregion Métodos
    }
}
