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
    public class DepartamentoController
    {

        #region Variáveis

          DepartamentoDAO departamentoDAO = new DepartamentoDAO();

        #endregion Variáveis


        #region Construtor
        public DepartamentoController() 
        {
            departamentoDAO = new DepartamentoDAO();
        }
        #endregion Construtor



        #region Métodos

        public int IncluirDepartaController(DepartamentoModel pDepartamentoModel)
        {
            try
            {
                return departamentoDAO.IncluirDepartaDAO(pDepartamentoModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarDepartaController(DepartamentoModel pDepartamentoModel)
        {
            try
            {
                return departamentoDAO.AlterarDepartaDAO(pDepartamentoModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirDepartaController(int pIdDepartamento)
        {
            try
            {
                return departamentoDAO.ExcluirDepartaDAO(pIdDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterRegistrosDepartamentos()
        {
            try
            {
                return departamentoDAO.ObterAllDepartamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable RecuperarGrupoDepartamentos(string pNome)
        {
            return departamentoDAO.ObterAllDepartamentosPorNome(pNome);
        }

        public void PesquisarDepartamentos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeDepartamento" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PopularCboDepartamento(ComboBox cbo)
        {
            try
            {
                if (departamentoDAO == null)
                {
                    departamentoDAO = new DepartamentoDAO();
                }
                cbo.DataSource = departamentoDAO.ObterAllDepartamentos();
                cbo.DisplayMember = "NomeDepartamento";
                cbo.ValueMember = "IdDepartamento";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
