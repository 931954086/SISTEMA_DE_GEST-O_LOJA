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
    public class EnderecoFunDAO
    {
        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno;


        public EnderecoFunDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }


        public EnderecoFunDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        public int IncluirEnderecoFunDAO(EnderecoFunModel pEnderecoFunModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoFunIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@logradourofun", pEnderecoFunModel.LogradouroFun);
                    comando.Parameters.AddWithValue("@numlogradourofun", pEnderecoFunModel.NumLogradouroFun);
                    comando.Parameters.AddWithValue("@cepfun", pEnderecoFunModel.CepFun);
                    comando.Parameters.AddWithValue("@idFuncionario", pEnderecoFunModel.Funcionario_Model.IdFuncionario);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoFunModel.Bairro_Model.IdBairro);

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



        public int AlterarEnderecoFunDAO(EnderecoFunModel pEnderecoFunModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoFunAlterar", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idenderecofun", pEnderecoFunModel.IdEnderecoFun);
                    comando.Parameters.AddWithValue("@logradourofun", pEnderecoFunModel.LogradouroFun);
                    comando.Parameters.AddWithValue("@numlogradourofun", pEnderecoFunModel.NumLogradouroFun);     
                    comando.Parameters.AddWithValue("@cepfun", pEnderecoFunModel.CepFun);
                    comando.Parameters.AddWithValue("@idFuncionario", pEnderecoFunModel.Funcionario_Model.IdFuncionario);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoFunModel.Bairro_Model.IdBairro);

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





        public int ExcluirEnderecoFunDAO(int pIdEnderecoFunModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoFunExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idenderecofun", pIdEnderecoFunModel);


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



        public DataTable ObterAllEnderecoFun()
        {
            try
            {
                return conexao.ExecDataTable("uspEnderecoFunTodosOsEnderecoFun", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
