using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class DepartamentoDAO
    {


        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public DepartamentoDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos


        public int IncluirDepartaDAO(DepartamentoModel pDepartamentoModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspDepartamentoIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomedepartamento", pDepartamentoModel.NomeDepartamento);
                    comando.Parameters.AddWithValue("@descricao", pDepartamentoModel.Descricao);
                    comando.Parameters.AddWithValue("@idempresa", pDepartamentoModel.EmpresaModel.IdEmpresa);
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



        public int AlterarDepartaDAO(DepartamentoModel pDepartamentoModel)
        {

            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspDepartamentoAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@iddepartamento",   pDepartamentoModel.IdDepartamento);
                    comando.Parameters.AddWithValue("@nomedepartamento", pDepartamentoModel.NomeDepartamento);
                    comando.Parameters.AddWithValue("@descricao", pDepartamentoModel.Descricao);
                    comando.Parameters.AddWithValue("@idempresa", pDepartamentoModel.EmpresaModel.IdEmpresa);
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



        public int ExcluirDepartaDAO(int pIdDepartamento)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspDepartamentoExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@iddepartamento", pIdDepartamento);
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



        public DataTable ObterAllDepartamentos()
        {
            return conexao.ExecDataTable("uspDepartamentoLocalizar", conexao.ConectarBD());
        }


        public DataTable ObterAllDepartamentosPorNome(string pNome)
        {
            throw new NotImplementedException();
        }

        #endregion Métodos
    }
}
