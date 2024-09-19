using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class BairroDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public BairroDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

     
        public int IncluirBairroDAO(BairroModel pBairroModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspBairroIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomebairro",   pBairroModel.NomeBairro);
                    comando.Parameters.AddWithValue("@idcidade",   pBairroModel.Cidade_Model.IdCidade);

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

   

        public int AlterarBairroDAO(BairroModel pBairroModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspBairroAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idbairro",   pBairroModel.IdBairro);
                    comando.Parameters.AddWithValue("@nomebairro", pBairroModel.NomeBairro);
                    comando.Parameters.AddWithValue("@idcidade",   pBairroModel.Cidade_Model.IdCidade);
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

        public int ExcluirBairroDAO(int pIdBairro)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspBairroExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idbairro", pIdBairro);
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

        public DataTable ObterAllBairros()
        {
            try
            {
                return conexao.ExecDataTable("uspBairroTodosBairros", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
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
