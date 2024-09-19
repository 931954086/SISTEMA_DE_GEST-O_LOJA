using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class FornecedorDAO
    {

        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public FornecedorDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirFornecedorDAO(FornecedorModel pFornecedorModel, EnderecoForModel pEnderecoForModel, TelefoneForModel pTelefoneForModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFornecedorIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@descfor", pFornecedorModel.DescFor);
                    comando.Parameters.AddWithValue("@nomefantasia", pFornecedorModel.NomeFantasia);
                    comando.Parameters.AddWithValue("@nif", pFornecedorModel.Nif);
                    comando.Parameters.AddWithValue("@email", pFornecedorModel.Email);
                    comando.Parameters.AddWithValue("@idsituacao ", pFornecedorModel.SituacaoModel.IdSituacao);

                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    //Recupera o id do Fornecedor cadastrado
                    int idforn = Convert.ToInt32(comando.ExecuteScalar());

                    if (pEnderecoForModel.LogradouroFor.Length != 0)
                    {
                        //Inclui o endereço do Fornecedor
                        EnderecoForDAO enderecoForDAO = new EnderecoForDAO(this.conn, transacao);

                        pEnderecoForModel.Fornecedor_Model.IdFornecedor = idforn;
                        enderecoForDAO.IncluirEnderecoForDAO(pEnderecoForModel);
                    }
                    if (pTelefoneForModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do Fornecedor
                        TelefoneForDAO telefoneForDAO = new TelefoneForDAO(this.conn, transacao);

                        pTelefoneForModel.Fornecedor_Model.IdFornecedor = idforn;
                        retorno = telefoneForDAO.IncluirTelefoneForDAO(pTelefoneForModel);
                    }
                }
            }
            catch (SqlException)
            {
                retorno = 0;
                throw;
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                if (retorno == 0)
                {
                    conexao.FinalizarTransacao(false);
                }
                else
                {
                    conexao.FinalizarTransacao(true);
                }
                conexao.FecharConexao();
            }
            return retorno;
        }


        public int AlterarFornecedorDAO(FornecedorModel pFornecedorModel, EnderecoForModel pEnderecoForModel, TelefoneForModel pTelefoneForModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFornecedorAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfornecedor", pFornecedorModel.IdFornecedor);
                    comando.Parameters.AddWithValue("@descfor", pFornecedorModel.DescFor);
                    comando.Parameters.AddWithValue("@nomefantasia", pFornecedorModel.NomeFantasia);
                    comando.Parameters.AddWithValue("@nif", pFornecedorModel.Nif);
                    comando.Parameters.AddWithValue("@email", pFornecedorModel.Email);
                    comando.Parameters.AddWithValue("@idsituacao ", pFornecedorModel.SituacaoModel.IdSituacao);

                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    comando.ExecuteNonQuery();
                    if (pEnderecoForModel.LogradouroFor.Length != 0)
                    {
                        //Inclui o endereço do Fornecedor
                        EnderecoForDAO enderecoForDAO = new EnderecoForDAO(this.conn, transacao);
                        pEnderecoForModel.Fornecedor_Model.IdFornecedor = pFornecedorModel.IdFornecedor;
                        enderecoForDAO.AlterarEnderecoForDAO(pEnderecoForModel);
                    }
                    if (pTelefoneForModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do Fornecedor
                        TelefoneForDAO telefoneForDAO = new TelefoneForDAO(this.conn, transacao);
                        pTelefoneForModel.Fornecedor_Model.IdFornecedor = pFornecedorModel.IdFornecedor;
                        retorno = telefoneForDAO.AlterarTelefoneForDAO(pTelefoneForModel);
                    }
                }
            }
            catch (SqlException)
            {
                retorno = 0;
                throw;
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                if (retorno == 0)
                {
                    conexao.FinalizarTransacao(false);
                }
                else
                {
                    conexao.FinalizarTransacao(true);
                }
                conexao.FecharConexao();
            }
            return retorno;
        }



        public int ExcluirFornecedorDAO(int pIdFornecedor)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFornecedorExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfornecedor", pIdFornecedor);
                    conexao.AbrirConexao();
                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
                throw;
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }


        public DataTable ObterAllFornecedores()
        {
            try
            {
                return conexao.ExecDataTable("uspFornecedorTodosFornecedores", this.conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos


    }
}
