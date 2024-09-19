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
    public class TelefoneEmpDAO
    {


        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public TelefoneEmpDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        public TelefoneEmpDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirTelefoneEmpreDAO(TelefoneEmpModel pTelefoneEmpModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreIncluir", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < pTelefoneEmpModel.ListTelefone.Count; i++)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@ddd", pTelefoneEmpModel.ListTelefone[i].DDD);
                        comando.Parameters.AddWithValue("@numerotelefone", pTelefoneEmpModel.ListTelefone[i].NumeroTelefone);
                        comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneEmpModel.ListTelefone[i].TipoTelefoneModel.IdTipoTelefone);
                        comando.Parameters.AddWithValue("@idemprea", pTelefoneEmpModel.ListTelefone[i].EmpresaModel.IdEmpresa);

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
        public int AlterarTelefoneEmpreDAO(TelefoneEmpModel pTelefoneEmpModel)
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
                dt = conexao.ExecDataTable("uspTelefoneEmpreLocalizar", "@idempresa", pTelefoneEmpModel.EmpresaModel.IdEmpresa);

                if (dt.Rows.Count > pTelefoneEmpModel.ListTelefone.Count)
                {
                    // excluir
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < pTelefoneEmpModel.ListTelefone.Count; i++)
                        {
                            if (dt.Rows[j]["IdTelefoneEmpre"].ToString() == pTelefoneEmpModel.ListTelefone[i].IdTelefoneEmpre.ToString())
                            {
                                bAchou = true;

                                // alterar
                                using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreAlterar", this.conn, this.tran))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;

                                    Alterar(pTelefoneEmpModel, comando, i);
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
                            ExcluirTelefoneEmprePorIdTelefoneDAO(Convert.ToInt16(dt.Rows[j]["IdTelefoneCli"]));
                        }
                    }
                }
                else if (dt.Rows.Count < pTelefoneEmpModel.ListTelefone.Count)
                {
                    // Incluir - Essa lógica funciona porque quando adiciona um telefone na lista ele preenche sempre linha mais em baixo
                    // do último registro do ListView.
                    for (int i = 0; i < pTelefoneEmpModel.ListTelefone.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["IdTelefoneCli"].ToString() == pTelefoneEmpModel.ListTelefone[i].IdTelefoneEmpre.ToString())
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
                            using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreIncluir", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Clear();
                                comando.Parameters.AddWithValue("@ddd", pTelefoneEmpModel.ListTelefone[i].DDD);
                                comando.Parameters.AddWithValue("@numerotelefone", pTelefoneEmpModel.ListTelefone[i].NumeroTelefone);
                                comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneEmpModel.ListTelefone[i].TipoTelefoneModel.IdTipoTelefone);
                                comando.Parameters.AddWithValue("@idemprea", pTelefoneEmpModel.ListTelefone[i].EmpresaModel.IdEmpresa);
                                comando.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreAlterar", this.conn, this.tran))
                            {
                                comando.CommandType = CommandType.StoredProcedure;

                                Alterar(pTelefoneEmpModel, comando, i);
                            }
                        }
                    }
                }
                else
                {
                    // alterar
                    using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreAlterar", this.conn, this.tran))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < pTelefoneEmpModel.ListTelefone.Count; i++)
                        {
                            Alterar(pTelefoneEmpModel, comando, i);
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
        private void Alterar(TelefoneEmpModel pTelefoneEmpModel, SqlCommand cmd, int indice)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idtelefoneempre", pTelefoneEmpModel.ListTelefone[indice].IdTelefoneEmpre);
                cmd.Parameters.AddWithValue("@ddd", pTelefoneEmpModel.ListTelefone[indice].DDD);
                cmd.Parameters.AddWithValue("@numerotelefone", pTelefoneEmpModel.ListTelefone[indice].NumeroTelefone);
                cmd.Parameters.AddWithValue("@idtipoTelefone", pTelefoneEmpModel.ListTelefone[indice].TipoTelefoneModel.IdTipoTelefone);
                cmd.Parameters.AddWithValue("@idemprea", pTelefoneEmpModel.ListTelefone[indice].EmpresaModel.IdEmpresa);


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }










        public int ExcluirTelefoneEmpreDAO(int pIdTelefoneEmpre)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspTelefoneEmpreExcluir", this.conn, this.tran))
                {
                    comando.Parameters.Clear();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idempresa", pIdTelefoneEmpre);

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

        public int ExcluirTelefoneEmprePorIdTelefoneDAO(int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspuspTelefoneEmpreExcluirPorIdTelefone", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idtelefoneempre", pId);

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
        /// <param name="pIdEmpresa">Identificador do Empresa.</param>
        /// <returns>IDataReader</returns>
        public DataTable ObterTelefonePorIdEmpresa(int pIdEmpresa)
        {
            try
            {
                return conexao.ExecDataTable("uspTelefoneEmpresaLocalizar", "@idempresa", pIdEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos







    }
}
