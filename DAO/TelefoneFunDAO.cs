using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class TelefoneFunDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public TelefoneFunDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        public TelefoneFunDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneFunDAO(TelefoneFunModel pTelefoneFunModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneFunIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < pTelefoneFunModel.ListTelefone.Count; i++)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@ddd", pTelefoneFunModel.ListTelefone[i].DDD);
                        comando.Parameters.AddWithValue("@numerotelefone", pTelefoneFunModel.ListTelefone[i].NumeroTelefone);
                        comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneFunModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                        comando.Parameters.AddWithValue("@idfuncionario", pTelefoneFunModel.ListTelefone[i].Funcionario_Model.IdFuncionario);

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

      
        public int AlterarTelefoneFunDAO(TelefoneFunModel pTelefoneFunModel)
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
                dt = conexao.ExecDataTable("uspTelefoneFunLocalizar", "@idfuncionario", pTelefoneFunModel.Funcionario_Model.IdFuncionario);

                if (dt.Rows.Count > pTelefoneFunModel.ListTelefone.Count)
                {
                    // excluir
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < pTelefoneFunModel.ListTelefone.Count; i++)
                        {
                            if (dt.Rows[j]["IdTelefoneFun"].ToString() == pTelefoneFunModel.ListTelefone[i].IdTelefoneFun.ToString())
                            {
                                bAchou = true;

                                // alterar
                                using (SqlCommand comando = new SqlCommand("uspTelefoneFunAlterar", this.conn, this.tran))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;

                                    Alterar(pTelefoneFunModel, comando, i);
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
                            ExcluirTelefoneFunDAO(Convert.ToInt16(dt.Rows[j]["IdTelefoneFun"]));
                        }
                    }
                }
                else if (dt.Rows.Count < pTelefoneFunModel.ListTelefone.Count)
                {
                    // Incluir - Essa lógica funciona porque quando adiciona um telefone na lista ele preenche sempre linha mais em baixo
                    // do último registro do ListView.
                    for (int i = 0; i < pTelefoneFunModel.ListTelefone.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["IdTelefoneFun"].ToString() == pTelefoneFunModel.ListTelefone[i].IdTelefoneFun.ToString())
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
                            using (SqlCommand comando = new SqlCommand("uspTelefoneFunIncluir", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Clear();
                                comando.Parameters.AddWithValue("@ddd", pTelefoneFunModel.ListTelefone[i].DDD);
                                comando.Parameters.AddWithValue("@numerotelefone", pTelefoneFunModel.ListTelefone[i].NumeroTelefone);
                                comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneFunModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                                comando.Parameters.AddWithValue("@idfuncionario", pTelefoneFunModel.ListTelefone[i].Funcionario_Model.IdFuncionario);

                                comando.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand comando = new SqlCommand("uspTelefoneFunlterar", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;

                                Alterar(pTelefoneFunModel, comando, i);
                            }
                        }
                    }
                }
                else
                {
                    // alterar
                    using (SqlCommand comando = new SqlCommand("uspTelefoneFunAlterar", this.conn, this.tran))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < pTelefoneFunModel.ListTelefone.Count; i++)
                        {
                            Alterar(pTelefoneFunModel, comando, i);
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
        private void Alterar(TelefoneFunModel pTelefoneFunModel, SqlCommand cmd, int indice)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idtelefonefun", pTelefoneFunModel.ListTelefone[indice].IdTelefoneFun);
                cmd.Parameters.AddWithValue("@ddd", pTelefoneFunModel.ListTelefone[indice].DDD);
                cmd.Parameters.AddWithValue("@numerotelefone", pTelefoneFunModel.ListTelefone[indice].NumeroTelefone);
                cmd.Parameters.AddWithValue("@idtipoTelefone", pTelefoneFunModel.ListTelefone[indice].TipoTelefone.IdTipoTelefone);
                cmd.Parameters.AddWithValue("@idfuncionario", pTelefoneFunModel.ListTelefone[indice].Funcionario_Model.IdFuncionario);


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int ExcluirTelefoneCliDAO(int pIdFun)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneFunExcluir", this.conn, this.tran))
                {
                    comando.Parameters.Clear();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfuncionario", pIdFun);

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

        public int ExcluirTelefoneFunDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneFunExcluirPorIdTelefone", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idfuncionario", pId);

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

     


        public DataTable ObterTelefonePorIdFuncionario(int pIdFuncionario)
        {
            try
            {
                return conexao.ExecDataTable("uspTelefoneFunLocalizar", "@idfuncionario", pIdFuncionario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}
