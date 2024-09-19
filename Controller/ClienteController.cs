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
    public class ClienteController
    {
        #region Variáveis

        ClienteDAO clienteDAO = new ClienteDAO();

        #endregion Variáveis

        #region Construtor
        public ClienteController()
        {
            clienteDAO = new ClienteDAO();

        }
        #endregion Construtor

        #region Métodos

        public int IncluirClienteController(ClienteModel pClienteModel, EnderecoCliModel pEnderecoCliModel, TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                return clienteDAO.IncluirClienteDAO(pClienteModel, pEnderecoCliModel, pTelefoneCliModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarClienteController(ClienteModel pClienteModel, EnderecoCliModel pEnderecoCliModel, TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                return clienteDAO.AlterarClienteDAO(pClienteModel, pEnderecoCliModel, pTelefoneCliModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirClienteController(int pIdCliente)
        {
            try
            {
                return clienteDAO.ExcluirClienteDAO(pIdCliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterRegistrosCliente()
        {
            try
            {
                return clienteDAO.ObterAllClientes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ContarClientesController()
        {
            DataTable clientes = clienteDAO.ObterAllClientes();
            return clientes.Rows.Count;
        }

        public DataTable RecuperarGrupoClientes(string pNome)
        {
            return clienteDAO.ObterAllClientes(pNome);
        }

        public void PesquisarClientes(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeCli" + " like '%{0}%'", texto.Replace("'", "''"));
        }

        public void PreencherCboCliente(ComboBox cbo)
        {
            try
            {
                if (clienteDAO == null)
                {
                    clienteDAO = new ClienteDAO();
                }
                cbo.DataSource = clienteDAO.ObterAllClientes();
                cbo.DisplayMember = "NomeCli";
                cbo.ValueMember = "IdCliente";
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion Métodos
    }
}
