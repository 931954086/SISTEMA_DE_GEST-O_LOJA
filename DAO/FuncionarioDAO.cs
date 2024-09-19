using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class FuncionarioDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public FuncionarioDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirFuncionarioDAO(FuncionarioModel pFuncionarioModel, EnderecoFunModel pEnderecoFunModel, TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFuncionarioIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomefun", pFuncionarioModel.NomeFunc);
                    comando.Parameters.AddWithValue("@nif", pFuncionarioModel.Nif);
                    comando.Parameters.AddWithValue("@foto", pFuncionarioModel.Foto);
                    comando.Parameters.AddWithValue("@idcargo", pFuncionarioModel.Cargo_Model.IdCargo);
                    comando.Parameters.AddWithValue("@email", pFuncionarioModel.Email);
                    comando.Parameters.AddWithValue("@idsituacao", pFuncionarioModel.Situacao_Model.IdSituacao);
                    comando.Parameters.AddWithValue("@iddepartamento", pFuncionarioModel.DepartamentoModel.IdDepartamento);
                    comando.Parameters.AddWithValue("@datacontratacao", pFuncionarioModel.DataContratacao);
                   
                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    //Recupera o id do funcionario cadastrado
                    int idfunc = Convert.ToInt32(comando.ExecuteScalar());

                    if (pEnderecoFunModel.LogradouroFun.Length != 0)
                    {
                        //Inclui o endereço do cliente
                        EnderecoFunDAO enderecoFunDAO = new EnderecoFunDAO(this.conn, transacao);

                        pEnderecoFunModel.Funcionario_Model.IdFuncionario = idfunc;
                        enderecoFunDAO.IncluirEnderecoFunDAO(pEnderecoFunModel);
                    }
                    if (pTelefoneFunModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do cliente
                        TelefoneFunDAO telefoneFunDAO = new TelefoneFunDAO(this.conn, transacao);

                        pTelefoneFunModel.Funcionario_Model.IdFuncionario = idfunc;
                        retorno = telefoneFunDAO.IncluirTelefoneFunDAO(pTelefoneFunModel);
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

        public int AlterarFuncionarioDAO(FuncionarioModel pFuncionarioModel, EnderecoFunModel pEnderecoFunModel, TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFuncionarioAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfuncionario", pFuncionarioModel.IdFuncionario);
                    comando.Parameters.AddWithValue("@nomefun", pFuncionarioModel.NomeFunc);
                    comando.Parameters.AddWithValue("@nif", pFuncionarioModel.Nif);
                    comando.Parameters.AddWithValue("@foto", pFuncionarioModel.Foto);
                    comando.Parameters.AddWithValue("@idcargo", pFuncionarioModel.Cargo_Model.IdCargo);
                    comando.Parameters.AddWithValue("@email", pFuncionarioModel.Email);
                    comando.Parameters.AddWithValue("@idsituacao", pFuncionarioModel.Situacao_Model.IdSituacao);
                    comando.Parameters.AddWithValue("@iddepartamento", pFuncionarioModel.DepartamentoModel.IdDepartamento);
                    comando.Parameters.AddWithValue("@datacontratacao", pFuncionarioModel.DataContratacao);

                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    comando.ExecuteNonQuery();
                    if (pEnderecoFunModel.LogradouroFun.Length != 0)
                    {
                        //Inclui o endereço do funcionario
                        EnderecoFunDAO enderecoFunDAO = new EnderecoFunDAO(this.conn, transacao);
                        pEnderecoFunModel.Funcionario_Model.IdFuncionario = pFuncionarioModel.IdFuncionario;
                        enderecoFunDAO.AlterarEnderecoFunDAO(pEnderecoFunModel);
                    }
                    if (pTelefoneFunModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do funcionario
                        TelefoneFunDAO telefoneFunDAO = new TelefoneFunDAO(this.conn, transacao);
                        pTelefoneFunModel.Funcionario_Model.IdFuncionario = pFuncionarioModel.IdFuncionario;
                        retorno = telefoneFunDAO.AlterarTelefoneFunDAO(pTelefoneFunModel);
                    }
                    MessageBox.Show("FEITO " + pFuncionarioModel.DepartamentoModel.IdDepartamento);
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

        public int ExcluirFuncionarioDAO(int idFuncionario)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspFuncionarioExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfuncionario", idFuncionario);
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


        public DataTable ObterAllFuncionarios()
        {
            try
            {
                return conexao.ExecDataTable("uspFuncionarioTodosFuncionarios", this.conn);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion Métodos
    }
}
