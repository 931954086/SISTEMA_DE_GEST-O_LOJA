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
    public class TipoTelefoneDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public TipoTelefoneDAO()
        {
            conexao = new AcessoBanco();
            conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTipoTelefoneDAO(TipoTelefoneModel pTipoTelefoneModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoTelefoneIncluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@desctipotel", pTipoTelefoneModel.DescTipoTelefone);

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

        public int AlterarTipoTelefoneDAO(TipoTelefoneModel pTipoTelefoneModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoTelefoneAlterar", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtipotelefone", pTipoTelefoneModel.IdTipoTelefone);
                    comando.Parameters.AddWithValue("@desctipotel", pTipoTelefoneModel.DescTipoTelefone);

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

        public int ExcluirTipoTelefoneDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoTelefoneExcluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtipotelefone", pId);

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

        public DataTable ObterTodosTipoTelefone()
        {
            try
            {
                return conexao.ExecDataTable("uspTipoTelefoneTodosTipoTelefone", conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
