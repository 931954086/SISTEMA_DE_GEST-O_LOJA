using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class FuncionarioController
    {
        #region Variáveis

        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

        #endregion Variáveis

        #region Métodos

        public int IncluirFuncionarioController(FuncionarioModel pFuncionarioModel, EnderecoFunModel pEndererecoFunModel, TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                return funcionarioDAO.IncluirFuncionarioDAO(pFuncionarioModel, pEndererecoFunModel, pTelefoneFunModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarFuncionarioController(FuncionarioModel pFuncionarioModel, EnderecoFunModel pEndererecoFunModel, TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                return funcionarioDAO.AlterarFuncionarioDAO(pFuncionarioModel, pEndererecoFunModel, pTelefoneFunModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirFuncionarioController(int pIdFuncionario)
        {
            try
            {
                return funcionarioDAO.ExcluirFuncionarioDAO(pIdFuncionario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterAllFuncionario()
        {
            try
            {
                return funcionarioDAO.ObterAllFuncionarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PesquisarFuncionario(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeFunc" + " like '%{0}%'", texto.Replace("'", "''"));
        }


        public void PreencherCboFuncionario(ComboBox cbo)
        {
            cbo.DataSource = funcionarioDAO.ObterAllFuncionarios();
            cbo.DisplayMember = "NomeFunc";
            cbo.ValueMember = "IdFuncionario";
        }

        #endregion Métodos
    }
}
