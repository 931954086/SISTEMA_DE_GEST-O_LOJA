using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class EstadoController
    {
        EstadoDAO estadoDAO = null;

        public EstadoController()
        {
            estadoDAO = new EstadoDAO();
        }

        public int IncluirEstadoController(EstadoModel pEstadoModel)
        {
            try
            {
                return estadoDAO.IncluirEstadoDAO(pEstadoModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarEstadoController(EstadoModel pEstadoModel)
        {
            try
            {
                return estadoDAO.AlterarEstadoDAO(pEstadoModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirEstadoController(int pIdEstado)
        {
            try
            {
                return estadoDAO.ExcluirEstadoDAO(pIdEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterRegistrosEstado()
        {
            return estadoDAO.ObterTodosEstados();
        }

        public DataSet ALLRegistrosEstado()
        {
            return estadoDAO.LocalizarTodosEstados();
        }

        public void PreencherCboEstado(ComboBox cbo)
        {
            try
            {
                if (estadoDAO == null)
                {
                    estadoDAO = new EstadoDAO();
                }
                cbo.DataSource = estadoDAO.ObterTodosEstados();
                cbo.DisplayMember = "NomeEstado";
                cbo.ValueMember = "IdEstado";
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void PesquisarEstados(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeEstado" + " like '%{0}%'", texto.Replace("'", "''"));
        }
    }
}
