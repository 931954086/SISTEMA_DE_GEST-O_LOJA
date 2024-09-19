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
    public class AluguerDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public AluguerDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        #endregion Construtor 

        #region Métodos


        public int IncluirAluguerDAO(AluguerModel pAluguerModel, ItemAluguerModel itemAluguerModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspAluguelIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parâmetros obrigatórios
                    comando.Parameters.AddWithValue("@clienteid", pAluguerModel.ClienteModel.Idcliente);
                    comando.Parameters.AddWithValue("@funcionarioid", pAluguerModel.FuncionarioModel.IdFuncionario);
                    comando.Parameters.AddWithValue("@datainicio", pAluguerModel.DataInicio);
                    comando.Parameters.AddWithValue("@datafim", pAluguerModel.DataFim);
                    comando.Parameters.AddWithValue("@valorbruto", pAluguerModel.ValorBrutoAluguer); // Valor Bruto
                    comando.Parameters.AddWithValue("@valorliquido", pAluguerModel.ValorliqVenda);  // Valor Líquido
                    comando.Parameters.AddWithValue("@clausulas", pAluguerModel.Clausula);
              
                    comando.Parameters.AddWithValue("@caucao", pAluguerModel.Caucao);
                    comando.Parameters.AddWithValue("@frete", pAluguerModel.Frete);
                    comando.Parameters.AddWithValue("@fretepreco", pAluguerModel.FretePreco);
                    // Parâmetros opcionais
                    comando.Parameters.AddWithValue("@dias", pAluguerModel.Dias);
                    comando.Parameters.AddWithValue("@desconto", pAluguerModel.Desconto);
                    comando.Parameters.AddWithValue("@imposto", pAluguerModel.Imposto);
                    comando.Parameters.AddWithValue("@dtcadaluguer", pAluguerModel.DataCadAluguer);
                    comando.Parameters.AddWithValue("@dtpagamento", pAluguerModel.Dtpagamento);
                    // O número da fatura pode ser gerado e passado para a inserção
                    comando.Parameters.AddWithValue("@numerofatura", pAluguerModel.NumeroFatura);
                    // Situação do aluguel
                    comando.Parameters.AddWithValue("@idsituacao", pAluguerModel.SituacaoModel.IdSituacao);

                    // Abre a conexão e executa a query
                    conexao.AbrirConexao();
                    this.tran = conexao.IniciarSqlTransaction(comando);
                    int idaluguer = Convert.ToInt32(comando.ExecuteScalar()); // Ver a stored procedure para entender porque uso o ExecuteScalar()
                                                                              //Inclui o codigo idAluguer
                  //  MessageBox.Show("A FALHA ESTA AQUI");
                    ItemAluguerDAO itemAluguerDAO = new ItemAluguerDAO(this.conn, this.tran);

                    itemAluguerModel.AluguerModel.Id = idaluguer;

                    retorno = itemAluguerDAO.IncluirItemAluguerDAO(itemAluguerModel);
                    retorno = comando.ExecuteNonQuery();
                }

            }
            catch (SqlException)
            {
                retorno = 0;
                throw;
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                if (retorno == 0)
                {
                    tran.Rollback();
                }
                else
                {
                    // Finaliza uma transação com Commit
                    tran.Commit();
                }
                // Fecha a conexão
                conn.Close();
            }
            return retorno;
        }



        public int AlterarAluguerDAO(AluguerModel pAluguerModel)
        {
            int retorno = 0;

           try
            {
                /*// Variável para armazenar o dia anterior obtido do banco de dados.
                int diaanterior = 0;
                // Cria o comando para buscar o dia anterior com base no Aluguer atual, sem passar parâmetros.
                using (SqlCommand comando = new SqlCommand("dbo.uspAluguelLocalizarDiaAnterior", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexao.AbrirConexao(); // Abre a conexão uma vez.
                  
                    diaanterior = Convert.ToInt32(comando.ExecuteScalar());
                }*/

                /* // Verifica se o dia anterior é diferente dos dias atuais do modelo.
                if (diaanterior != pAluguerModel.Dias)
                {
                    // Se o dia for diferente, atualiza todos os campos.
                    using (SqlCommand comando = new SqlCommand("dbo.uspAluguelAlterarTudo", this.conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;


                      // Executa o comando de alteração.
                        retorno = comando.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Se os dias forem iguais, atualiza apenas os campos específicos.
                    using (SqlCommand comando = new SqlCommand("dbo.uspAluguelAlterar", this.conn))
                    {

                    }
                }*/
                using (SqlCommand comando = new SqlCommand("uspAluguelIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@clienteid", pAluguerModel.Id);
             
                   // comando.Parameters.AddWithValue("@lavagem", pAluguerModel.Lavagem);
                   // comando.Parameters.AddWithValue("@lavagempreco", pAluguerModel.LavagemPreco);

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

        public int ExcluirAluguerDAO(int pIdAluguer)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspAluguelExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", pIdAluguer);
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

        public DataTable ObterAllAlugueres()
        {
            try
            {
                return conexao.ExecDataTable("uspAluguelLocalizar", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GerarNumeroNtVenda()
        {
            DataTable dt = new DataTable();
            dt = conexao.ExecDataTable("uspAlugueisAgendamentoGerarNumeroNota");

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }
        #endregion Métodos



    }

}
