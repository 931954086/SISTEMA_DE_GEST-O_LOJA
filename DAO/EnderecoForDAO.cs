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
    public class EnderecoForDAO
    {
        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno;


        public EnderecoForDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }


        public EnderecoForDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }
        public int IncluirEnderecoForDAO(EnderecoForModel pEnderecoForModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoForIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@logradourofor", pEnderecoForModel.LogradouroFor);
                    comando.Parameters.AddWithValue("@numlogradourofor", pEnderecoForModel.NumLogradouroFor);
                    comando.Parameters.AddWithValue("@cepfor", pEnderecoForModel.CepFor);
                    comando.Parameters.AddWithValue("@idfornecedor", pEnderecoForModel.Fornecedor_Model.IdFornecedor);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoForModel.Bairro_Model.IdBairro);

                    //   conexao.AbrirConexao();
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



        public int AlterarEnderecoForDAO(EnderecoForModel pEnderecoForModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoForAlterar", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idenderecofor", pEnderecoForModel.IdEnderecoFor);
                    comando.Parameters.AddWithValue("@logradourofor", pEnderecoForModel.LogradouroFor);
                    comando.Parameters.AddWithValue("@numlogradourofor", pEnderecoForModel.NumLogradouroFor);
                    comando.Parameters.AddWithValue("@cepfor", pEnderecoForModel.CepFor);
                    comando.Parameters.AddWithValue("@idfornecedor", pEnderecoForModel.Fornecedor_Model.IdFornecedor);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoForModel.Bairro_Model.IdBairro);


                    //   conexao.AbrirConexao();
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



        public int ExcluirEnderecoForDAO(int pIdEnderecoForModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoForExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idendereco", pIdEnderecoForModel);


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


   

        public DataTable ObterAllEnderecoFor()
        {
            try
            {
                return conexao.ExecDataTable("uspEnderecoForTodosOsEnderecoFor", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
