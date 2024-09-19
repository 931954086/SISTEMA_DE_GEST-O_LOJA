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
    public class ClienteDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public ClienteDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        /// <summary>
        /// Inclusão de uma nova Cliente
        /// </summary>
        /// <param name="pClienteModel">Classe ClienteModel</param>
        /// <returns>Código da cidade que foi incluída.</returns>
        public int IncluirClienteDAO(ClienteModel pClienteModel, EnderecoCliModel pEnderecoCliModel, TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspClienteIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomecli", pClienteModel.Nomecli);
                    comando.Parameters.AddWithValue("@emailcli", pClienteModel.Emailcli);
                    comando.Parameters.AddWithValue("@nif", pClienteModel.NIf);
                    comando.Parameters.AddWithValue("@idsituacao", pClienteModel.Situacao_Model.IdSituacao);

                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    int codcli = Convert.ToInt32(comando.ExecuteScalar());
                    if (pEnderecoCliModel.LogradouroCli.Length != 0)
                    {
                        //Inclui o endereço do cliente
                        EnderecoCliDAO enderecoCliDAO = new EnderecoCliDAO(this.conn, transacao);

                        pEnderecoCliModel.Cliente_Model.Idcliente = codcli;
                        enderecoCliDAO.IncluirEnderecoCliDAO(pEnderecoCliModel);
                    }

                    if (pTelefoneCliModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do cliente
                        TelefoneCliDAO telefoneCliDAO = new TelefoneCliDAO(this.conn, transacao);

                        pTelefoneCliModel.Cliente.Idcliente = pEnderecoCliModel.Cliente_Model.Idcliente;
                        retorno = telefoneCliDAO.IncluirTelefoneCliDAO(pTelefoneCliModel);
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
                    // Finaliza uma transação com RollBack
                    conexao.FinalizarTransacao(false);
                }
                else
                {
                    // Finaliza uma transação com Commit
                    conexao.FinalizarTransacao(true);
                }
                // Fecha a conexão
                conexao.FecharConexao();
            }
            return retorno;
        }

        /// <summary>
        /// Alteração de uma Cliente
        /// </summary>
        /// <param name="pClienteModel">Classe ClienteModel</param>
        /// <returns>Código da cidade que foi incluída.</returns>
        public int AlterarClienteDAO(ClienteModel pClienteModel, EnderecoCliModel pEnderecoCliModel, TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspClienteAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcliente", pClienteModel.Idcliente);
                    comando.Parameters.AddWithValue("@nomecli", pClienteModel.Nomecli);
                    comando.Parameters.AddWithValue("@emailcli", pClienteModel.Emailcli);
                    comando.Parameters.AddWithValue("@nif", pClienteModel.NIf);
                    comando.Parameters.AddWithValue("@idsituacao", pClienteModel.Situacao_Model.IdSituacao);

                    //Abre uma conexão
                    conexao.AbrirConexao();

                    //Abre uma transação
                    var transacao = conexao.IniciarSqlTransaction(comando);

                    //Atribui o id do cliente que foi incluído
                    comando.ExecuteNonQuery();

                    if (pEnderecoCliModel.LogradouroCli.Length != 0)
                    {
                        //Inclui o endereço do cliente
                        EnderecoCliDAO enderecoCliDAO = new EnderecoCliDAO(this.conn, transacao);
                        pEnderecoCliModel.Cliente_Model.Idcliente = pClienteModel.Idcliente;
                        enderecoCliDAO.AlterarEnderecoCliDAO(pEnderecoCliModel);
                    }
                    if (pTelefoneCliModel.ListTelefone.Count != 0)
                    {
                        //Inclui o telefone do cliente
                        TelefoneCliDAO telefoneCliDAO = new TelefoneCliDAO(this.conn, transacao);
                        pTelefoneCliModel.Cliente.Idcliente = pClienteModel.Idcliente;
                        retorno = telefoneCliDAO.AlterarTelefoneCliDAO(pTelefoneCliModel);
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

        public int ExcluirClienteDAO(int pIdCliente)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspClienteExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcliente", pIdCliente);
                    conexao.AbrirConexao();
                    comando.ExecuteNonQuery();
                }
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

        public DataTable ObterAllClientes()
        {
            try
            {
                return conexao.ExecDataTable("uspClienteTodosClientes", this.conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma relação de registros iniciados pelo valor do parametro pNome.
        /// </summary>
        /// <param name="pNome">Texto pesquisado no campo NomeCli na tabela de clientes. </param>
        /// <returns>Relação de registro em um DataTable.</returns>
        public DataTable ObterAllClientes(string pNome)
        {
            try
            {
                return conexao.ExecDataTable("uspClienteLocalizarPorNome");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
