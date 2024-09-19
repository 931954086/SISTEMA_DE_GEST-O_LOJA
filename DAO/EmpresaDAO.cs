using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class EmpresaDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public EmpresaDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        public int IncluirEmpresaDAO(EmpresaModel pEmpresaModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEmpresaIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nome",     pEmpresaModel.NomeEmpresa);
                    comando.Parameters.AddWithValue("@nif",      pEmpresaModel.Nif);
                    comando.Parameters.AddWithValue("@fundacao", pEmpresaModel.Fundacao);
                    comando.Parameters.AddWithValue("@site",     pEmpresaModel.Site);
                    comando.Parameters.AddWithValue("@emailcontato", pEmpresaModel.Email);
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


        public int AlterarEmpresaDAO(EmpresaModel pEmpresaModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEmpresaAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idempresa", pEmpresaModel.IdEmpresa);
                    comando.Parameters.AddWithValue("@nome",      pEmpresaModel.NomeEmpresa);
                    comando.Parameters.AddWithValue("@nif",       pEmpresaModel.Nif);
                    comando.Parameters.AddWithValue("@fundacao",  pEmpresaModel.Fundacao);
                    comando.Parameters.AddWithValue("@site",      pEmpresaModel.Site);
                    comando.Parameters.AddWithValue("@emailcontato", pEmpresaModel.Email);
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


        public int ExcluirEmpresaDAO(int pIdEmpresa)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEmpresaExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idempresa", pIdEmpresa);
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



        public DataTable ObterAllEmpresa()
        {
            try
            {
                return conexao.ExecDataTable("uspEmpresaLocalizar", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void PesquisarEmpresas(DataGridView dtg, string texto)
        {
            ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeEmpresa" + " like '%{0}%'", texto.Replace("'", "''"));
        }



        public string ObterNomeEmpresaDAO()
        {
            try
            {
                DataTable dataTable = conexao.ExecDataTable("uspObterNomeEmpresa", conexao.ConectarBD());
                if (dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0]["NomeEmpresa"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Você pode querer logar a exceção ou tratá-la de outra forma aqui
                throw new Exception("Erro ao obter o nome da empresa", ex);
            }
        }


    }
}
