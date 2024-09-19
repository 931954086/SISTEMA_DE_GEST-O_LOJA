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
    public class ItemAgendamentoDAO
    {
        #region Variáveis
        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;


        #endregion Variáveis

        #region Construtor
        public ItemAgendamentoDAO()
        {
      
        }
        public ItemAgendamentoDAO(SqlConnection pCon, SqlTransaction transacao)
        {
                this.conn = pCon;
                this.tran = transacao;
        }
        #endregion Construtor


        #region Métodos
        public int IncluirItemAgendamentoDAO(ItemAgendamentoModel itemAgendamentoModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspIncluirItemAgendamento", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Loop para inserir cada item do agendamento
                    for (int i = 0; i < itemAgendamentoModel.ListaItensAgendamentoModel.Count; i++)
                    {
                        comando.Parameters.Clear(); // Limpa os parâmetros anteriores

                        // Adiciona os novos parâmetros para o item atual
                        comando.Parameters.AddWithValue("@quantidadeitemagendamento", itemAgendamentoModel.ListaItensAgendamentoModel[i].QuantidadeItemAgendamento);
                        comando.Parameters.AddWithValue("@valorunit", itemAgendamentoModel.ListaItensAgendamentoModel[i].ValorUnit);
                        comando.Parameters.AddWithValue("@idagendamento", itemAgendamentoModel.AgendamentoModel.Id);
                        comando.Parameters.AddWithValue("@idmaterial", itemAgendamentoModel.ListaItensAgendamentoModel[i].MaterialModel.IdMaterial);

                        // Executa o comando para inserir o item
                        comando.ExecuteNonQuery();
                    }

                    retorno = 1; // Indica sucesso
                }
            }
            catch (Exception ex)
            {
                retorno = 0; // Indica falha
                throw; // Re-throw da exceção para ser tratada em outro nível
            }
            return retorno; // Retorna o status da operação
        }





        public int AlterarItemAgendamentoDAO(ItemAgendamentoModel itemAgendamentoModel)
        {
            throw new NotImplementedException();
        }

        public int ExcluirItemAgendamentoDAO(int idItemAgendamento)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterAllItemAgendamentos()
        {
            throw new NotImplementedException();
        }
        public void AtualizarEstoque(ItemAgendamentoModel itemAgendamentoModel, SqlTransaction tran)
        {
            throw new NotImplementedException();
        }

        #endregion Métodos
    }
}


