using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class HistoricoPrecoProdutoDAO
    {
        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno;

       

        public HistoricoPrecoProdutoDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        public HistoricoPrecoProdutoDAO()
        {
        }

        public int IncluirHistoricoPrecoProdutoDAO(HistoricoPrecoProdutoModel hppc)
        {
            int retorno = 0;
            try
            {
               
                using (SqlCommand comando = new SqlCommand("uspHistoricoPrecoProdutoIncluir", this.conn, tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idproduto", hppc.Produto_model.Idproduto);
                    comando.Parameters.AddWithValue("@precoproduto", hppc.Produto_model.Precoproduto);
                    comando.Parameters.AddWithValue("@datacadastro", DateTime.Now);

                    //conexao.AbrirConexao();
                    //retorno = comando.ExecuteNonQuery();

                    comando.ExecuteNonQuery();
                }
            }
            /* catch (Exception)
             {
                 throw;
             }
             finally
             {
                 conexao.FecharConexao();
             }
             return retorno;*/
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            return retorno;
        }





        public int AlterarHistoricoPrecoProdutoDAO(HistoricoPrecoProdutoModel hppc)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspHistoricoPrecoProdutoAlterar", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idproduto", hppc.Produto_model.Idproduto);
                    comando.Parameters.AddWithValue("@precoproduto", hppc.Produto_model.Precoproduto);
                    comando.Parameters.AddWithValue("@datacadastro", DateTime.Now);
                    //conexao.AbrirConexao();
                    //retorno = comando.ExecuteNonQuery();
                    comando.ExecuteNonQuery();
                }
            }
            /* catch (Exception)
             {
                 throw;
             }
             finally
             {
                 conexao.FecharConexao();
             }
             return retorno;*/
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            return retorno;
        }


        public int ExcluirIncluirHistoricoPrecoProdutoDAO(int pIdHistoricoPrecoProdutoModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoCliExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idproduto", pIdHistoricoPrecoProdutoModel);


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



        public DataTable ObterAllIncluirHistoricoPrecoProdutoDAO()
        {
            try
            {
                return conexao.ExecDataTable("uspHistoricoPrecoProdutoCliTodosOsHistoricoPrecoProdutos", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
