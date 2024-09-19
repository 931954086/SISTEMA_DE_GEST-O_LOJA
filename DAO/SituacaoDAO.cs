using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class SituacaoDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public SituacaoDAO()
        {
            conexao = new AcessoBanco();
            conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirSituacaoDAO(SituacaoModel pSituacaoModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspSituacaoIncluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@descsituacao", pSituacaoModel.DescSituacao);

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

        public int AlterarSituacaoDAO(SituacaoModel pSituacaoModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspSituacaoAlterar", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idsituacao", pSituacaoModel.IdSituacao);
                    comando.Parameters.AddWithValue("@descsituacao", pSituacaoModel.DescSituacao);

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

        public int ExcluirSituacaoDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspSituacaoExcluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idsituacao", pId);

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

        public DataTable ObterTodasSituacoes()
        {
            try
            {
                return conexao.ExecDataTable("uspSituacaoTodasSituacoes", conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
