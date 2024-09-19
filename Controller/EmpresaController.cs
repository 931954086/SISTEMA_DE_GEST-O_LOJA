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
    public class EmpresaController
    {
        #region Variáveis

        EmpresaDAO empresaDAO = new EmpresaDAO();

        #endregion Variáveis

        #region Métodos

        public int IncluirEmpresaController(EmpresaModel pEmpresaModel)
        {
            try
            {
                return empresaDAO.IncluirEmpresaDAO(pEmpresaModel);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int AlterarEmpresaController(EmpresaModel pEmpresaModel)
        {
            try
            {
                return empresaDAO.AlterarEmpresaDAO(pEmpresaModel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int ExcluirEmpresaController(int pIdEmpresa)
        {
            try
            {
                return empresaDAO.ExcluirEmpresaDAO(pIdEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterRegistrosEmpresas()
        {
            try
            {
                return empresaDAO.ObterAllEmpresa();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void PesquisarEmpresas(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeEmpresa" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PopularCboEmpresa(ComboBox cbo)
        {
            try
            {
                if (empresaDAO == null)
                {
                    empresaDAO = new EmpresaDAO();
                }
                cbo.DataSource = empresaDAO.ObterAllEmpresa();
                cbo.DisplayMember = "NomeEmpresa";
                cbo.ValueMember = "IdEmpresa";
            }
            catch (Exception)
            {
                throw;
            }
        }



        public string ObterNomeEmpresaController()
        {
            try
            {
                return empresaDAO.ObterNomeEmpresaDAO();
            }
            catch (Exception)
            {
                // Tratar exceção ou logar a mensagem
                throw;
            }
        }
        #endregion Métodos
    }
}
