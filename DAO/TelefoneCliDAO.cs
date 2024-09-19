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
    public class TelefoneCliDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public TelefoneCliDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        public TelefoneCliDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneCliDAO(TelefoneCliModel pTelefoneCliModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneCliIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@ddd", pTelefoneCliModel.ListTelefone[i].DDD);
                        comando.Parameters.AddWithValue("@numerotelefone", pTelefoneCliModel.ListTelefone[i].NumeroTelefone);
                        comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneCliModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                        comando.Parameters.AddWithValue("@idcliente", pTelefoneCliModel.ListTelefone[i].Cliente.Idcliente);

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




        /// <summary>
        /// Alteração/Inclusão 
        /// </summary>
        /// <param name="pTelefoneCliModel"></param>
        /// <returns></returns>
        public int AlterarTelefoneCliDAO(TelefoneCliModel pTelefoneCliModel)
        {
            Boolean bAchou = false;
            try
            {
                if (conexao == null)
                {
                    conexao = new AcessoBanco();
                }
                DataTable dt = new DataTable();

                // Recupera todos os telefones cadastrado do cliente
                dt = conexao.ExecDataTable("uspTelefoneCliLocalizar", "@idcliente", pTelefoneCliModel.Cliente.Idcliente);

                if (dt.Rows.Count > pTelefoneCliModel.ListTelefone.Count)
                {
                    // excluir
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
                        {
                            if (dt.Rows[j]["IdTelefoneCli"].ToString() == pTelefoneCliModel.ListTelefone[i].IdTelefoneCli.ToString())
                            {
                                bAchou = true;

                                // alterar
                                using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;

                                    Alterar(pTelefoneCliModel, comando, i);
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
                            ExcluirTelefoneCliPorIdTelefoneDAO(Convert.ToInt16(dt.Rows[j]["IdTelefoneCli"]));
                        }
                    }
                }
                else if (dt.Rows.Count < pTelefoneCliModel.ListTelefone.Count)
                {
                    // Incluir - Essa lógica funciona porque quando adiciona um telefone na lista ele preenche sempre linha mais em baixo
                    // do último registro do ListView.
                    for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["IdTelefoneCli"].ToString() == pTelefoneCliModel.ListTelefone[i].IdTelefoneCli.ToString())
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
                            using (SqlCommand comando = new SqlCommand("uspTelefoneCliIncluir", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Clear();
                                comando.Parameters.AddWithValue("@ddd", pTelefoneCliModel.ListTelefone[i].DDD);
                                comando.Parameters.AddWithValue("@numerotelefone", pTelefoneCliModel.ListTelefone[i].NumeroTelefone);
                                comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneCliModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                                comando.Parameters.AddWithValue("@idcliente", pTelefoneCliModel.ListTelefone[i].Cliente.Idcliente);

                                comando.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;

                                Alterar(pTelefoneCliModel, comando, i);
                            }
                        }
                    }
                }
                else
                {
                    // alterar
                    using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
                        {
                            Alterar(pTelefoneCliModel, comando, i);
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
        private void Alterar(TelefoneCliModel pTelCliModel, SqlCommand cmd, int indice)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idtelefonecli", pTelCliModel.ListTelefone[indice].IdTelefoneCli);
                cmd.Parameters.AddWithValue("@ddd", pTelCliModel.ListTelefone[indice].DDD);
                cmd.Parameters.AddWithValue("@numerotelefone", pTelCliModel.ListTelefone[indice].NumeroTelefone);
                cmd.Parameters.AddWithValue("@idtipoTelefone", pTelCliModel.ListTelefone[indice].TipoTelefone.IdTipoTelefone);
                cmd.Parameters.AddWithValue("@idcliente", pTelCliModel.ListTelefone[indice].Cliente.Idcliente);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExcluirTelefoneCliDAO(int pIdCli)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneCliExcluir", this.conn, this.tran))
                {
                    comando.Parameters.Clear();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcliente", pIdCli);

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

        public int ExcluirTelefoneCliPorIdTelefoneDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneCliExcluirPorIdTelefone", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtelefonecli", pId);

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

        /// <summary>
        /// Recuperar todos os telefones do cliente.
        /// </summary>
        /// <param name="pIdCliente">Identificador do cliente.</param>
        /// <returns>IDataReader</returns>
        public DataTable ObterTelefoneCliPorId(int pIdCliente)
        {
            try
            {
                return conexao.ExecDataTable("uspTelefoneCliLocalizar", "@idcliente", pIdCliente);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion Métodos
    }
}
