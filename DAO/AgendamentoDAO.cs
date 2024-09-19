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
    public class AgendamentoDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        #endregion Construtor 

        public AgendamentoDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        public AgendamentoDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }


        public int IncluirAgendamentoDAO(AgendamentoModel agendamentoModel, ItemAgendamentoModel itemAgendamentoModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspAgendamentoIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clienteid", agendamentoModel.ClienteModel.Idcliente);
                    comando.Parameters.AddWithValue("@funcionarioid", agendamentoModel.FuncionarioModel.IdFuncionario);
                    comando.Parameters.AddWithValue("@datainicio", agendamentoModel.DataInicio);
                    comando.Parameters.AddWithValue("@datafim", agendamentoModel.DataFim);
                    comando.Parameters.AddWithValue("@valorbruto", agendamentoModel.ValorBruto);
                    comando.Parameters.AddWithValue("@valorliquido", agendamentoModel.ValorLiquido);
                    comando.Parameters.AddWithValue("@clausulas", agendamentoModel.Clausulas);
                    comando.Parameters.AddWithValue("@caucao", agendamentoModel.Caucao);
                    comando.Parameters.AddWithValue("@frete", agendamentoModel.Frete);
                    comando.Parameters.AddWithValue("@fretepreco", agendamentoModel.FretePreco);
                    comando.Parameters.AddWithValue("@dias", agendamentoModel.Dias);
                    comando.Parameters.AddWithValue("@desconto", agendamentoModel.Desconto);
                    comando.Parameters.AddWithValue("@imposto", agendamentoModel.Imposto);
                    comando.Parameters.AddWithValue("@dtcadagendamento", agendamentoModel.DataCadAgendamento);
                    comando.Parameters.AddWithValue("@dtpagamento", agendamentoModel.DataPagamento);
                    comando.Parameters.AddWithValue("@numerofatura", agendamentoModel.NumeroFatura);
                    comando.Parameters.AddWithValue("@idsituacao", agendamentoModel.SituacaoModel.IdSituacao);

                    /* int idagendamento = Convert.ToInt32(comando.ExecuteScalar());
                   // Inserir os itens agendados
                   ItemAgendamentoDAO itemAgendamentoDAO = new ItemAgendamentoDAO(this.conn, this.tran);
                   itemAgendamentoModel.AgendamentoModel.Id = idagendamento;

                   foreach (var item in itemAgendamentoModel.ListaItensAgendamentoModel)
                   {
                       itemAgendamentoDAO.IncluirItemAgendamentoDAO(item);
                   }
                   return idagendamento;*/ 

                    // Abre a conexão e executa a query
                    conexao.AbrirConexao();
                    this.tran = conexao.IniciarSqlTransaction(comando);
                    int idagendamento = Convert.ToInt32(comando.ExecuteScalar()); // Ver a stored procedure para entender porque uso o ExecuteScalar()
                                                                                  //Inclui o codigo idAluguer
                    ItemAgendamentoDAO itemAgendamentoDAO = new ItemAgendamentoDAO(this.conn, this.tran);
                    itemAgendamentoModel.AgendamentoModel.Id = idagendamento;

                    retorno = itemAgendamentoDAO.IncluirItemAgendamentoDAO(itemAgendamentoModel);
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


        public int AlterarAgendamentoDAO(AgendamentoModel agendamentoModel)
        {
            throw new NotImplementedException();
        }

        public int ExcluirAgendamentoDAO(int pIdAgendamento)
        {
            throw new NotImplementedException();
        }

        public string GerarNumeroFatura()
        {
            throw new NotImplementedException();
        }

        public DataTable ObterAllAgendamentos()
        {
            throw new NotImplementedException();
        }
    }

}
