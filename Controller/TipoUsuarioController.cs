using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class TipoUsuarioController
    {
        #region Variáveis

        private TipoUsuarioDAO tipoUsuarioDAO = null;

        #endregion Variáveis

        #region Construtor

        public TipoUsuarioController()
        {
            tipoUsuarioDAO = new TipoUsuarioDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTipoUsuarioController(TipoUsuarioModel pTipoUsuarioModel)
        {
            return tipoUsuarioDAO.IncluirTipoUsuarioDAO(pTipoUsuarioModel);
        }

        public int AlterarTipoUsuarioController(TipoUsuarioModel pTipoUsuarioModel)
        {
            return tipoUsuarioDAO.AlterarTipoUsuarioDAO(pTipoUsuarioModel);
        }

        public int ExcluirTipoUsuarioController(int pIdTipoUsuario)
        {
            return tipoUsuarioDAO.ExcluirTipoUsuarioDAO(pIdTipoUsuario);
        }

        public DataTable ObterRegistrosTipoUsuarios()
        {
            return tipoUsuarioDAO.ObterTodosOsTipoUsuarios();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarTipoUsuarios(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeTipoUsuario" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PreencherCboTipoUsuario(ComboBox cbo)
        {
            cbo.DataSource = tipoUsuarioDAO.ObterTodosOsTipoUsuarios();
            cbo.DisplayMember = "NomeTipoUsuario";
            cbo.ValueMember = "IdTipoUsuario";
        }
        #endregion Métodos



    }
}
