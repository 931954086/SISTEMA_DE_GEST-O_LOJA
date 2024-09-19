using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System.Windows;
using System.Windows.Documents;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class ProdutoDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor        

        public ProdutoDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        public ProdutoDAO(SqlConnection _conn, SqlTransaction _tran)
        {
            this.conexao = new AcessoBanco();
            if (_conn == null)
            {
                this.conn = this.conexao.ConectarBD();
            }
            else
            {
                this.conn = _conn;
            }
            this.tran = _tran;
        }

        #endregion Construtor

        #region Metodos

        public int IncluirProdutoDAO(ProdutoModel pProdutoModel)
        {
            this.conn = conexao.AbrirConexao();
            this.tran = conexao.IniciarSqlTransaction(conn);

            SqlCommand comando = new SqlCommand("uspProdutoIncluir", this.conn, this.tran);
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descproduto", pProdutoModel.Descproduto);
                comando.Parameters.AddWithValue("@precoproduto", pProdutoModel.Precoproduto);
                comando.Parameters.AddWithValue("@quantidadeestoque", pProdutoModel.Quantidadeeestoque);
                comando.Parameters.AddWithValue("@qtdminimaestoque", pProdutoModel.Qteminimaestoque);
                comando.Parameters.AddWithValue("@codigobarra", pProdutoModel.Codigobarra);
                comando.Parameters.AddWithValue("@idsituacao", pProdutoModel.Situacao_Model.IdSituacao);
                comando.Parameters.AddWithValue("@foto", pProdutoModel.Foto);
                comando.Parameters.AddWithValue("@descricaoproduto", pProdutoModel.Descricaoproduto);

                int idproduto = Convert.ToInt32(comando.ExecuteScalar());

                HistoricoPrecoProdutoModel hppc = new HistoricoPrecoProdutoModel();
                hppc.Produto_model.Idproduto = idproduto;
                hppc.Produto_model.Precoproduto = pProdutoModel.Precoproduto;

                HistoricoPrecoProdutoDAO historicoPrecoProdutoDAO = new HistoricoPrecoProdutoDAO(this.conn, tran);
                historicoPrecoProdutoDAO.IncluirHistoricoPrecoProdutoDAO(hppc);

            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                if (retorno != 0)
                {
                    this.tran.Commit();

                }
                else
                {
                    this.tran.Rollback();
                }
                this.conexao.FecharConexao();
            }
            return retorno;
        }




        public int AlterarProdutoDAO(ProdutoModel pProdutoModel, bool pGravarHistorico)
        {
            this.conn = conexao.AbrirConexao();
            this.tran = conexao.IniciarSqlTransaction(conn);

            SqlCommand comando = new SqlCommand("uspProdutoAlterar", this.conn, this.tran);
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idproduto", pProdutoModel.Idproduto);
                comando.Parameters.AddWithValue("@descproduto", pProdutoModel.Descproduto);
                comando.Parameters.AddWithValue("@precoproduto", pProdutoModel.Precoproduto);
                comando.Parameters.AddWithValue("@quantidadeestoque", pProdutoModel.Quantidadeeestoque);
                comando.Parameters.AddWithValue("@qtdminimaestoque", pProdutoModel.Qteminimaestoque);
                comando.Parameters.AddWithValue("@codigobarra", pProdutoModel.Codigobarra);
                comando.Parameters.AddWithValue("@idsituacao", pProdutoModel.Situacao_Model.IdSituacao);
                comando.Parameters.AddWithValue("@foto", pProdutoModel.Foto);
                comando.Parameters.AddWithValue("@descricaoproduto", pProdutoModel.Descricaoproduto);

                conexao.AbrirConexao();
                retorno = comando.ExecuteNonQuery();

                if (pGravarHistorico)
                {
                    HistoricoPrecoProdutoModel hppc = new HistoricoPrecoProdutoModel();
                    hppc.Produto_model.Idproduto = pProdutoModel.Idproduto;
                    hppc.Produto_model.Precoproduto = pProdutoModel.Precoproduto;

                    HistoricoPrecoProdutoDAO historicoPrecoProdutoDAO = new HistoricoPrecoProdutoDAO(this.conn, tran);
                    historicoPrecoProdutoDAO.AlterarHistoricoPrecoProdutoDAO(hppc);
                }
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                if (retorno != 0)
                {
                    this.tran.Commit();
                }
                else
                {
                    this.tran.Rollback();
                }
                this.conexao.FecharConexao();
            }
            return retorno;
        }

        public int ExcluirProdutoDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspProdutoExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idproduto", pId);

                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
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

        public DataTable ObterTodosProdutos()
        {
            try
            {
                return conexao.ExecDataTable("uspProdutoTodosProdutos", this.conn);
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
        }

        public decimal ObterEstoqueProduto(int idproduto)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspObterQuantidadeEstoqueProduto", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Clear();
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@idproduto", idproduto);
                    conexao.AbrirConexao();
                    return Convert.ToDecimal(comando.ExecuteScalar());
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
        }

        //private decimal ObterQuantidadeEstoque(int idproduto)
        //{
        //    try
        //    {
        //        using (SqlCommand comando = new SqlCommand("uspObterQuantidadeEstoqueProduto", this.conn))
        //        {
        //            comando.CommandType = CommandType.StoredProcedure;
        //            comando.Parameters.Clear();
        //            comando.Prepare();
        //            comando.Parameters.AddWithValue("@idproduto", idproduto);
        //            conexao.AbrirConexao();
        //            return Convert.ToDecimal(comando.ExecuteScalar());
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        retorno = 0;
        //        throw;
        //    }
        //    finally
        //    {
        //        conexao.FecharConexao();
        //    }
        //}

      /*   public void AtualizarEstoque(ItemVendaModel itemVendaModel, SqlTransaction transacao, int indice)
          {
              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.Connection = transacao.Connection;
                  cmd.Transaction = transacao;
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "uspVendaSubtraiEstoque";
                  cmd.Parameters.Clear();
                  try
                  {
                      cmd.Parameters.AddWithValue("@idproduto", itemVendaModel.ListaItensVendaModel[indice].Produto_Model.Idproduto);
                      cmd.Parameters.AddWithValue("@qtdinformada", Convert.ToDecimal(itemVendaModel.ListaItensVendaModel[indice].Quantidadeitemvenda));

                      cmd.ExecuteNonQuery();
                  }
                  catch (SqlException ex)
                  {
                      retorno = 0;
                      throw;
                  }
                  catch (Exception ex)
                  {
                      retorno = 0;
                      throw;
                  }
              }
          }*/

        /*
        public void AtualizarEstoque(ItemVendaModel objVenda)
        {
           // MessageBox.Show(Convert.ToString(objVenda.Quantidadeitemvenda));
        }*/






        #endregion Metodos
    }
}
