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
    public class EnderecoCliDAO
    {
        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno;


        public EnderecoCliDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }


        public EnderecoCliDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        public int IncluirEnderecoCliDAO(EnderecoCliModel pEnderecoCliModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoCliIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@logradourocli",   pEnderecoCliModel.LogradouroCli);
                    comando.Parameters.AddWithValue("@numlogradourocli",pEnderecoCliModel.NumLogradouroCli);
                    comando.Parameters.AddWithValue("@cepcli",   pEnderecoCliModel.CepCli);
                    comando.Parameters.AddWithValue("@idcliente",pEnderecoCliModel.Cliente_Model.Idcliente);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoCliModel.Bairro_Model.IdBairro);

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



        public int AlterarEnderecoCliDAO(EnderecoCliModel pEnderecoCliModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoCliAlterar", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idenderecocli", pEnderecoCliModel.IdEnderecoCli);
                    comando.Parameters.AddWithValue("@logradourocli", pEnderecoCliModel.LogradouroCli);
                    comando.Parameters.AddWithValue("@numlogradourocli", pEnderecoCliModel.NumLogradouroCli);
                    comando.Parameters.AddWithValue("@cepcli", pEnderecoCliModel.CepCli);
                    comando.Parameters.AddWithValue("@idcliente",pEnderecoCliModel.Cliente_Model.Idcliente);
                    comando.Parameters.AddWithValue("@idbairro", pEnderecoCliModel.Bairro_Model.IdBairro);

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





        public int ExcluirEnderecoCliDAO(int pIdEnderecoCliModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspEnderecoCliExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idenderecocli", pIdEnderecoCliModel);


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



        public DataTable ObterAllEnderecoCli()
        {
            try
            {
                return conexao.ExecDataTable("uspEnderecoCliTodosOsEndereco", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
