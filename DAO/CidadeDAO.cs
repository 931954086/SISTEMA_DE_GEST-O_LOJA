using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class CidadeDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public CidadeDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        /// <summary>
        /// Inclusão de uma nova Cidade
        /// </summary>
        /// <param name="pCidadeModel">Classe CidadeModel</param>
        /// <returns>Código da cidade que foi incluída.</returns>
        public int IncluirCidadeDAO(CidadeModel pCidadeModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCidadeIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomeCidade", pCidadeModel.NomeCidade);
                    comando.Parameters.AddWithValue("@idEstado", pCidadeModel.EstadoModel.IdEstado);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }

        /// <summary>
        /// Alteração de uma Cidade
        /// </summary>
        /// <param name="pCidadeModel">Classe CidadeModel</param>
        /// <returns>Código da cidade que foi incluída.</returns>
        public int AlterarCidadeDAO(CidadeModel pCidadeModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCidadeAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idCidade", pCidadeModel.IdCidade);
                    comando.Parameters.AddWithValue("@nomeCidade", pCidadeModel.NomeCidade);
                    comando.Parameters.AddWithValue("@idEstado", pCidadeModel.EstadoModel.IdEstado);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }

        public int ExcluirCidadeDAO(int pIdCidade)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCidadeExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idCidade", pIdCidade);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }

        public DataTable ObterAllCidades()
        {
            try
            {
                return conexao.ExecDataTable("uspCidadeTodasAsCidades", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
