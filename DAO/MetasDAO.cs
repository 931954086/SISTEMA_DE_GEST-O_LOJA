using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class MetasDAO
    {
    

        #region Variáveis
        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public MetasDAO(SqlConnection connection)
        {
 
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }
        #endregion Construtor
        public bool InserirMetaDAO(MetasModel meta)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspInserirMetaVendas", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@AnoMes", meta.AnoMes);
                    comando.Parameters.AddWithValue("@MetaClientes", meta.MetaClientes);
                    comando.Parameters.AddWithValue("@MetaVendas", meta.MetaVendas);
                    comando.Parameters.AddWithValue("@MetaProdutos", meta.MetaProdutos);

                    this.conn.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                Console.WriteLine($"Erro ao inserir meta: {ex.Message}");
                return false;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public MetasModel ObterMetaPorAnoMes(DateTime anoMes)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM MetasVendas WHERE AnoMes = @AnoMes", this.conn))
                {
                    comando.Parameters.AddWithValue("@AnoMes", anoMes);
                    this.conn.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MetasModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                AnoMes = Convert.ToDateTime(reader["AnoMes"]),
                                MetaClientes = Convert.ToInt32(reader["MetaClientes"]),
                                MetaVendas = Convert.ToDecimal(reader["MetaVendas"]),
                                MetaProdutos = Convert.ToInt32(reader["MetaProdutos"])
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                Console.WriteLine($"Erro ao obter meta: {ex.Message}");
                return null;
            }
            finally
            {
                this.conn.Close();
            }
        }

        internal void AtualizarMetaDAO(MetasModel meta)
        {
            throw new NotImplementedException();
        }

        internal void ExcluirMetaDAO(int id)
        {
            throw new NotImplementedException();
        }

        internal List<MetasModel> ObterMetasDAO(int ano, int mes)
        {
            throw new NotImplementedException();
        }
    }

}
