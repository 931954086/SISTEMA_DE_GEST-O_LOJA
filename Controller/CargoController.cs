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
    public class CargoController
    {
        #region Variáveis

        private CargoDAO cargoDAO = null;

        #endregion Variáveis

        #region Construtor

        public CargoController()
        {
            cargoDAO = new CargoDAO();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirCargoController(CargoModel cargoModel)
        {
            return cargoDAO.IncluirCargoDAO(cargoModel);
        }

        public int AlterarCargoController(CargoModel cargoModel)
        {
            return cargoDAO.AlterarCargoDAO(cargoModel);
        }

        public int ExcluirCargoController(int pIdCargo)
        {
            return cargoDAO.ExcluirCargoDAO(pIdCargo);
        }

        /// <summary>
        /// Método que recupera do banco de dados todos os registros.
        /// </summary>
        /// <param name="dtg"></param>
        /// <returns>DataTable</returns>
        public DataTable ObterRegistrosCargo()
        {
            return cargoDAO.ObterAllCargos();
        }

        /// <summary>
        /// Método que solicita a pesquisa do texto dentro do datagridview
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="texto"></param>
        public void PesquisarCargos(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeCargo" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PreencherCboCargo(ComboBox cbo)
        {
            try
            {
                if (cargoDAO == null)
                {
                    cargoDAO = new CargoDAO();
                }
                cbo.DataSource = cargoDAO.ObterAllCargos();
                cbo.DisplayMember = "NomeCidade";
                cbo.ValueMember = "IdCidade";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PopularCboEstado(ComboBox cbo)
        {
            EstadoController estadoController = new EstadoController();
            estadoController.PreencherCboEstado(cbo);
        }

        #endregion Métodos
    }
}

