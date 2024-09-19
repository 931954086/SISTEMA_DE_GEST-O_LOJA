using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA_DE_GESTÃO_LOJA.Model;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class EstadoDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public EstadoDAO()
        {
            conexao = new AcessoBanco();
            conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirEstadoDAO(EstadoModel pEstadoModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEstadoIncluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomeestado", pEstadoModel.NomeEstado);
                    comando.Parameters.AddWithValue("@uf", pEstadoModel.Uf);

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

        public int AlterarEstadoDAO(EstadoModel pEstadoModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEstadoAlterar", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idestado", pEstadoModel.IdEstado);
                    comando.Parameters.AddWithValue("@nomeestado", pEstadoModel.NomeEstado);
                    comando.Parameters.AddWithValue("@uf", pEstadoModel.Uf);

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

        public int ExcluirEstadoDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEstadoExcluir", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idestado", pId);

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

        public DataTable ObterTodosEstados()
        {
            try
            {
                return conexao.ExecDataTable("uspEstadoLocalizar", conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet LocalizarTodosEstados()
        {
            try
            {
                return conexao.ExecDataSet("uspEstadoLocalizar");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
