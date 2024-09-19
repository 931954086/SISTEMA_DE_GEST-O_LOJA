using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class FornecedorController
    {
        #region Variáveis

        FornecedorDAO fornecedorDAO = new FornecedorDAO();

        #endregion Variáveis

        #region Métodos

        public int IncluirFornecedorController(FornecedorModel pFornecedorModel, EnderecoForModel pEndererecoForModel, TelefoneForModel pTelefoneForModel)
        {
            try
            {
                return fornecedorDAO.IncluirFornecedorDAO(pFornecedorModel, pEndererecoForModel, pTelefoneForModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlterarFornecedorController(FornecedorModel pFornecedorModel, EnderecoForModel pEndererecoForModel, TelefoneForModel pTelefoneForModel)
        {
            try
            {
                return fornecedorDAO.AlterarFornecedorDAO(pFornecedorModel, pEndererecoForModel, pTelefoneForModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirFornecedorController(int pIdFornecedor)
        {
            try
            {
                return fornecedorDAO.ExcluirFornecedorDAO(pIdFornecedor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObterAllFornecedores()
        {
            try
            {
                return fornecedorDAO.ObterAllFornecedores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PesquisarFornecedores(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeFantasia" + " like '%{0}%'", texto.Replace("'", "''"));
        }


        public void PreencherCboFornecedor(ComboBox cbo)
        {
            cbo.DataSource = fornecedorDAO.ObterAllFornecedores();
            cbo.DisplayMember = "NomeFantasia";
            cbo.ValueMember   = "IdFornecedor";
        }

        #endregion Métodos
    }
}
