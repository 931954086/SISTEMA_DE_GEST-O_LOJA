using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class TipoUsuarioDAO
    {


        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public TipoUsuarioDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor




        #region Métodos
        public int IncluirTipoUsuarioDAO(TipoUsuarioModel pTipoUsuarioModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoUsuarioIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nometipousuario", pTipoUsuarioModel.NomeTipoUsuario);
                    comando.Parameters.AddWithValue("@siglatipousuario", pTipoUsuarioModel.SiglaTipoUsuario);
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



        public int AlterarTipoUsuarioDAO(TipoUsuarioModel pTipoUsuarioModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoUsuarioAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtipousuario",      pTipoUsuarioModel.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@nometipousuario",    pTipoUsuarioModel.NomeTipoUsuario);
                    comando.Parameters.AddWithValue("@siglatipousuario",   pTipoUsuarioModel.SiglaTipoUsuario);
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



        public int ExcluirTipoUsuarioDAO(int pIdTipoUsuario)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTipoUsuarioExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtipousuario", pIdTipoUsuario);
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


        public DataTable ObterTodosOsTipoUsuarios()
        {
            try
            {
                return conexao.ExecDataTable("uspTipoUsuarioTodos", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion Métodos











    }
}
