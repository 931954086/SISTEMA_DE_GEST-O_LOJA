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
    public class TelefoneForDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public TelefoneForDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        public TelefoneForDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneForDAO(TelefoneForModel pTelefoneForModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneForIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < pTelefoneForModel.ListTelefone.Count; i++)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@ddd", pTelefoneForModel.ListTelefone[i].DDD);
                        comando.Parameters.AddWithValue("@numerotelefone", pTelefoneForModel.ListTelefone[i].NumeroTelefone);
                        comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneForModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                        comando.Parameters.AddWithValue("@idfornecedor", pTelefoneForModel.ListTelefone[i].Fornecedor_Model.IdFornecedor);

                        comando.ExecuteNonQuery();
                        //retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            return retorno;
        }




        public int AlterarTelefoneForDAO(TelefoneForModel pTelefoneForModel)
        {
            Boolean bAchou = false;
            try
            {
                if (conexao == null)
                {
                    conexao = new AcessoBanco();
                }
                DataTable dt = new DataTable();

                // Recupera todos os telefones cadastrado do funcionario
                dt = conexao.ExecDataTable("uspTelefoneForLocalizar", "@idfornecedor", pTelefoneForModel.Fornecedor_Model.IdFornecedor);

                if (dt.Rows.Count > pTelefoneForModel.ListTelefone.Count)
                {
                    // excluir
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < pTelefoneForModel.ListTelefone.Count; i++)
                        {
                            if (dt.Rows[j]["IdTelefoneFor"].ToString() == pTelefoneForModel.ListTelefone[i].IdTelefoneFor.ToString())
                            {
                                bAchou = true;

                                // alterar
                                using (SqlCommand comando = new SqlCommand("uspTelefoneForAlterar", this.conn, this.tran))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;

                                    Alterar(pTelefoneForModel, comando, i);
                                }
                                break;
                            }
                            else
                            {
                                bAchou = false;
                            }
                        }
                        if (!bAchou)
                        {
                            // excluir
                            ExcluirTelefoneForDAO(Convert.ToInt16(dt.Rows[j]["IdTelefoneFor"]));
                        }
                    }
                }
                else if (dt.Rows.Count < pTelefoneForModel.ListTelefone.Count)
                {
                    // Incluir - Essa lógica funciona porque quando adiciona um telefone na lista ele preenche sempre linha mais em baixo
                    // do último registro do ListView.
                    for (int i = 0; i < pTelefoneForModel.ListTelefone.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["IdTelefoneFor"].ToString() == pTelefoneForModel.ListTelefone[i].IdTelefoneFor.ToString())
                            {
                                bAchou = true;
                                break;
                            }
                            else
                            {
                                bAchou = false;
                            }
                        }
                        if (!bAchou)
                        {
                            using (SqlCommand comando = new SqlCommand("uspTelefoneForIncluir", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Clear();
                                comando.Parameters.AddWithValue("@ddd", pTelefoneForModel.ListTelefone[i].DDD);
                                comando.Parameters.AddWithValue("@numerotelefone", pTelefoneForModel.ListTelefone[i].NumeroTelefone);
                                comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneForModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                                comando.Parameters.AddWithValue("@idfornecedor", pTelefoneForModel.ListTelefone[i].Fornecedor_Model.IdFornecedor);
                                comando.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand comando = new SqlCommand("uspTelefoneForAlterar", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;

                                Alterar(pTelefoneForModel, comando, i);
                            }
                        }
                    }
                }
                else
                {
                    // alterar
                    using (SqlCommand comando = new SqlCommand("uspTelefoneForAlterar", this.conn, this.tran))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < pTelefoneForModel.ListTelefone.Count; i++)
                        {
                            Alterar(pTelefoneForModel, comando, i);
                        }
                    }
                }
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            return retorno;
        }

        /// <summary>
        /// Rotina interna da classe. Não publicar
        /// </summary>
        /// <param name="pTelCliModel">Objeto TelefoneCliModel.</param>
        /// <param name="cmd">Objeto SqlCommand.</param>
        /// <param name="indice">Indice do for que pesquisa os elementos do List.</param>
        private void Alterar(TelefoneForModel pTelefoneForModel, SqlCommand cmd, int indice)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idtelefonefor", pTelefoneForModel.ListTelefone[indice].IdTelefoneFor);
                cmd.Parameters.AddWithValue("@ddd", pTelefoneForModel.ListTelefone[indice].DDD);
                cmd.Parameters.AddWithValue("@numerotelefone", pTelefoneForModel.ListTelefone[indice].NumeroTelefone);
                cmd.Parameters.AddWithValue("@idtipoTelefone", pTelefoneForModel.ListTelefone[indice].TipoTelefone.IdTipoTelefone);
                cmd.Parameters.AddWithValue("@idfornecedor", pTelefoneForModel.ListTelefone[indice].Fornecedor_Model.IdFornecedor);


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int ExcluirTelefoneForDAO(int pIdFor)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneForExcluir", this.conn, this.tran))
                {
                    comando.Parameters.Clear();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfornecedor", pIdFor);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                retorno = 0;
                throw;
            }
            return retorno;
        }


        public DataTable ObterTelefonePorIdFornecedor(int pIdFornecedor)
        {
            try
            {
                return conexao.ExecDataTable("uspTelefoneForLocalizar", "@idfornecedor", pIdFornecedor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
