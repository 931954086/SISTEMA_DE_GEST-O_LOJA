 using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class NtVendaDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private SqlTransaction tran = null;
        private int retorno = 1;

        #endregion Variáveis

        #region Construtor

        public NtVendaDAO()
        {
            this.conexao = new AcessoBanco();
            this.conn = this.conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos

        public int IncluirNtVendaDAO(NtVendaModel pNtVendaModel, ItemVendaModel pItemVendaModel)
        {
            int retorno = 0;
            SqlCommand comando = new SqlCommand("uspNtVendaIncluir", this.conn);
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@numerofatura", pNtVendaModel.Numerofatura);
                comando.Parameters.AddWithValue("@dtpagamento", pNtVendaModel.Dtpagamento);
                comando.Parameters.AddWithValue("@valorbrutovenda", pNtVendaModel.Valorbrutovenda);
                comando.Parameters.AddWithValue("@descontovenda", pNtVendaModel.Descontovenda);
                comando.Parameters.AddWithValue("@valorliqvenda", pNtVendaModel.ValorliqVenda);
                comando.Parameters.AddWithValue("@imposto", pNtVendaModel.Imposto);
                comando.Parameters.AddWithValue("@idcliente", pNtVendaModel.Cliente_Model.Idcliente);
                comando.Parameters.AddWithValue("@idfuncionario", pNtVendaModel.Funcionario_Model.IdFuncionario);
                comando.Parameters.AddWithValue("@idsituacao", pNtVendaModel.Situacao_Model.IdSituacao);

                //Abre uma conexão
                conexao.AbrirConexao();
                //Abre uma transação
                this.tran = conexao.IniciarSqlTransaction(comando);
                int idntvenda = Convert.ToInt32(comando.ExecuteScalar()); // Ver a stored procedure para entender porque uso o ExecuteScalar()
                //Inclui o codigo idVenda
                ItemVendaDAO itemVendaDAO = new ItemVendaDAO(this.conn, this.tran);

                 pItemVendaModel.Ntvenda_Model.Idntvenda = idntvenda;
                 retorno = itemVendaDAO.IncluirItemVendaDAO(pItemVendaModel);
    
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




        public int AlterarNtVendaDAO(NtVendaModel pNtVendaModel, ItemVendaModel pItemVendaModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspNtVendaAlterar", conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idntvenda", pNtVendaModel.Idntvenda);
                    comando.Parameters.AddWithValue("@numerofatura", pNtVendaModel.Numerofatura);
                    comando.Parameters.AddWithValue("@dtpagamento", pNtVendaModel.Dtpagamento);
                    comando.Parameters.AddWithValue("@valorbrutovenda", pNtVendaModel.Valorbrutovenda);
                    comando.Parameters.AddWithValue("@descontovenda", pNtVendaModel.Descontovenda);
                    comando.Parameters.AddWithValue("@valorliqvenda", pNtVendaModel.ValorliqVenda);
                    comando.Parameters.AddWithValue("@imposto", pNtVendaModel.Imposto);
                    comando.Parameters.AddWithValue("@idcliente", pNtVendaModel.Cliente_Model.Idcliente);
                    comando.Parameters.AddWithValue("@idfuncionario", pNtVendaModel.Funcionario_Model.IdFuncionario);

                    conexao.AbrirConexao();
                    var transacao = conexao.IniciarSqlTransaction(comando);
                    comando.ExecuteNonQuery();

                    // Inclui os Itens da Venda
                    //ItemVendaDAO itemVendaDAO = new ItemVendaDAO(comando);

                    ItemVendaDAO itemVendaDAO = new ItemVendaDAO(this.conn, transacao);
                    pItemVendaModel.Ntvenda_Model.Idntvenda = pNtVendaModel.Idntvenda;

                    itemVendaDAO.AlterarItemVendaDAO(pItemVendaModel);
                }
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
                    // Finaliza uma transação com RollBack
                    conexao.FinalizarTransacao(false);
                }
                else
                {
                    // Finaliza uma transação com Commit
                    conexao.FinalizarTransacao(true);
                }
                // Fecha a conexão
                conexao.FecharConexao();
            }
            return retorno;
        }

        public int ExcluirNtVendaDAO(int idntvenda)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspNtVendaExluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idntvenda", idntvenda);
                    conexao.AbrirConexao();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }

        public DataTable ObterTodosNtVenda()
        {
            try
            {
                return conexao.ExecDataTable("uspNtVendaTodosNtVenda", this.conn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Localiza e recupera a Nota pelo Número da Fatura
        /// </summary>
        /// <param name="pNumerofatura">Número da fatura.</param>
        /// <returns>DataTable</returns>
        public DataTable ObterNtVenda(int pNumerofatura)
        {
            try
            {
                return conexao.ExecDataTable("uspNtVendaTodosNtVenda", "@numerofatura", pNumerofatura);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GerarNumeroNtVenda()
        {
            DataTable dt = new DataTable();
            dt = conexao.ExecDataTable("uspNtVendaGerarNumeroNota");

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }

        public DataSet PopularConsultaNtVenda()
        {
            string strSql = string.Empty;
            try
            {
                using (SqlConnection objConexao = new SqlConnection(conexao.ObterStringConexao()))
                {
                    ////////////////// CLIENTE //////////////////////////

                    //Cria um DataSet que engloba o dataset Cliente e o dataset NtVenda
                    DataSet ds = new DataSet("CLIENTENTVENDA");

                    //DataAdapter para Cliente
                    // "SELECT IdCliente, NomeCli FROM Cliente WHERE IdSituacao = 1";
                    strSql = "uspObterClientesAtivos";
                    SqlDataAdapter daCliente = new SqlDataAdapter(strSql, objConexao);

                    //Mapeia a tabela Cliente ao DataAdapter respectivo
                    daCliente.TableMappings.Add("Table", "Cliente");

                    // Preenche o DataSet CLIENTENTVENDA com a tabela Cliente
                    daCliente.Fill(ds);

                    ////////////////// TELEFONECLI //////////////////////

                    //DataAapter para o TelefoneCli
                    //strSql = "SELECT A.DDD, A.NumeroTelefone as [Nº Tel], B.DescTipoTel as [Tipo Tel], A.IdCliente";
                    //strSql += " FROM TelefoneCli A Inner Join TipoTelefone B On A.IdTipoTelefone = B.IdTipoTelefone";
                    strSql = "uspObterTelefoneCliente";
                    SqlDataAdapter daTelCli = new SqlDataAdapter(strSql, objConexao);

                    // Mapeia a tabela TelefoneCli ao DataAdapter respectiov
                    daTelCli.TableMappings.Add("Table", "TelefoneCli");

                    //Preenche o DataSet CLIENTENTVENDA com a tabela Cliente
                    daTelCli.Fill(ds);

                    ////////////////// NTVENDA /////////////////////

                    //Cria o DataAdapter daNtVenda
                    //strSql = "SELECT A.NumeroFatura as [Nº Fatura], A.DtVenda as [Dt. Venda], A.ValorBrutoVenda as [Valor Bruto], A.DescontoVenda as [Desconto],";
                    //strSql += " A.Imposto, A.ValorLiqVenda as [Valor Liq], B.DescSituacao as [Situação], A.IdCliente, A.IdNtVenda";
                    //strSql += " FROM NtVenda A";
                    //strSql += " Inner Join Situacao B on A.IdSituacao = B.IdSituacao";
                    strSql = "uspObterVendas";
                    SqlDataAdapter daNtVenda = new SqlDataAdapter(strSql, objConexao);

                    //Mapeia a tabela Orderes ao DataAdapter respectivo
                    daNtVenda.TableMappings.Add("Table", "NtVenda");

                    //Preenche o DataSet ClienteNtVenda com a tabela NtVenda
                    daNtVenda.Fill(ds);

                    ///////////////// ITEMVENDA ////////////////////////

                    //Cria o DataAdapter daItemVenda com a consulta da tabela Order Details
                    //strSql = "SELECT C.NumeroFatura as [Nº Fatura], A.IdProduto as [Código Produto], B.DescProduto as [Produto], A.ValorUnit as [Valor Unit],";
                    //strSql += " A.QuantidadeItemVenda as [Quantidade], A.IdNtVenda";
                    //strSql += " FROM ItemVenda A Inner Join Produto B On A.IdProduto = B.IdProduto";
                    //strSql += " Inner Join NtVenda C On A.IdNtVenda = C.IdNtVenda";
                    strSql = "uspObterItemVendas";
                    SqlDataAdapter daItemVenda = new SqlDataAdapter(strSql, objConexao);

                    //Mapeia a tabela Order Detalis ao DataAdapter respectivo
                    daItemVenda.TableMappings.Add("Table", "ItemVenda");

                    //Preenche o DataSet ClienteNtVenda com a tabela Orders Details
                    daItemVenda.Fill(ds);

                    //////////////// COMEÇA A FAZER A RELAÇÃO ENTRE AS TABELAS //////////////////////////////////////////

                    DataRelation relCliNtVenda;
                    DataColumn colunaCliente;
                    DataColumn colunaNtVenda;

                    //Atribui a coluna IdCliente da tabela Cliente.
                    colunaCliente = ds.Tables["Cliente"].Columns["IdCliente"];

                    //Atribui a coluna IdCliente da tabela NtVenda.
                    colunaNtVenda = ds.Tables["NtVenda"].Columns["IdCliente"];

                    //Relaciona as colunas IdCliente das tabelas Cliente e NtVenda
                    relCliNtVenda = new DataRelation("RelClienteNtVenda", colunaCliente, colunaNtVenda);

                    // Adiciona a relação relClienteNtVenda dentro do dataset
                    ds.Relations.Add(relCliNtVenda);

                    //////////////////////////////////////////////////////

                    DataRelation relCliTel;
                    DataColumn colunaClienteIdCliente;
                    DataColumn colunaTelefoneIdCliente;

                    //Atribui a coluna IdCliente da tabela Cliente.
                    colunaClienteIdCliente = ds.Tables["Cliente"].Columns["IdCliente"];

                    //Atribui a coluna IdCliente da tabela TelefoneCli.
                    colunaTelefoneIdCliente = ds.Tables["TelefoneCli"].Columns["IdCliente"];

                    //Relaciona as colunas IdCliente das tabelas Cliente e TelefoneCli
                    relCliTel = new DataRelation("RelClienteTelefoneCli", colunaClienteIdCliente, colunaTelefoneIdCliente);
                    ds.Relations.Add(relCliTel);

                    //////////////////////////////////////////////////////
                    DataRelation relNtVenda_ItemVenda;
                    DataColumn coluna_NtVenda;
                    DataColumn coluna_ItemVenda;

                    //Atribui a coluna IdNtvenda da tabela NtVenda.
                    coluna_NtVenda = ds.Tables["NtVenda"].Columns["IdNtVenda"];

                    // Atribui a coluna IdNtVenda da tabela ItemVenda.
                    coluna_ItemVenda = ds.Tables["ItemVenda"].Columns["IdNtVenda"];

                    //Relaciona as colunas IdNtVenda das tabelas NtVenda e ItemVenda
                    relNtVenda_ItemVenda = new DataRelation("RelNtVendaItemVenda", coluna_NtVenda, coluna_ItemVenda);

                    //Adiciona a relação relNtVendaItemVenda dentro do dataset
                    ds.Relations.Add(relNtVenda_ItemVenda);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: -> " + ex.Message + "\n\n" + ex.TargetSite);
                throw;
            }
        }

        /// <summary>
        /// Recupera os dados de faturamento de um número de faturamento.
        /// </summary>
        /// <param name="numeronotafiscal">Número da fatura</param>
        /// <returns>DataSet</returns>
        public DataSet LocalizarNotaFiscalVenda(string numerofatura)
        {
            try
            {
                return conexao.ExecDataSet("uspNtVendaEmitirNotaFiscal", "@numerofatura", numerofatura);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataSet LocalizarNotaFiscalVendaEspecifico(string numerofatura)
        {
            try
            {
                return conexao.ExecDataSet("uspNtVendaEmitirNotaFiscalEspecifico", "@numerofatura", numerofatura);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GraficoCircularObterTotalVendasDAO()
        {
            try
            {

                    SqlCommand cmd = new SqlCommand("dbo.uspTotalVendasPorProduto", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GraficoBarraObterDadosVendasDAO()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.uspTotalVendasPorProdutoGBarras", this.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }









        #endregion Métodos
    }
}

